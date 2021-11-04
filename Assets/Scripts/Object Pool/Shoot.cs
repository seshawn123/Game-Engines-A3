using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	[SerializeField] private float delay = 0.5f;
	[SerializeField] private GameObject bullet;
	GameObject projectile;
	private float lastTime;

	// Update is called once per frame    
	private void Update()
	{
		if (Time.time - lastTime > delay)
		{
			//if (Input.GetKey(KeyCode.Space))
			//	SpawnBomb();

			if(Input.GetKey(KeyCode.Space))
				SpawnBombFromPool();
		}
		if(projectile != null)
			projectile.GetComponent<Rigidbody>().velocity = transform.forward * 20;
	}

    private void SpawnBomb()
    {
        lastTime = Time.time;
        Vector2 position = transform.position;
        var projectile = Instantiate(bullet, position, Quaternion.identity);
    }

    private void SpawnBombFromPool()
	{
		lastTime = Time.time;
		Vector2 position = transform.position;
		projectile = BasicPool.Instance.GetPool();
		projectile.transform.position = position;
	}


}