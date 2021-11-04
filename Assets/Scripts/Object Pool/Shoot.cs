using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private float throwRate = 0.5f;
    [SerializeField] private float bulletSpeed = 20f;

    private float lastTime;

    void Update()
    {
        if (Time.time - lastTime > throwRate)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ObjectPoolSpawn();
            }
        }
    }

    private void ObjectPoolSpawn()
    {
        lastTime = Time.time;

        Vector2 position = transform.position;

        var bullet = BasicPool.Instance.GetPool();
        bullet.transform.position = position;

        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = new Vector2(player.transform.localScale.x * bulletSpeed, 0);
    }
}