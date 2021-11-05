using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Robot")
        {
            BasicPool.Instance.AddPool(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            BasicPool.Instance.AddPool(gameObject);
        }
    }
}