using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public static BasicPool Instance { get; private set; }

    private Queue<GameObject> availableObjects = new Queue<GameObject>();


    private void Awake()
    {
        Instance = this;
        IncreasePool();
    }

    public GameObject GetPool()
    {
        if (availableObjects.Count == 0)
            IncreasePool();

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }

    private void IncreasePool()
    {
        for (int i = 0; i < 10; i++)
        {
            var instToAdd = Instantiate(prefab);
            instToAdd.transform.SetParent(transform);
            AddPool(instToAdd);
        }
    }

    public void AddPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
}