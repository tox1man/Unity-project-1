using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHitDetector : MonoBehaviour
{
    void Awake()
    {
        //Debug.Log("awake");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

            Debug.Log($"Bullet hit {other.gameObject.tag}");
            //HitEnemy();
        }
        else if (!other.gameObject.CompareTag("Enemy") && !other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Debug.Log($"Bullet hit {other.gameObject.tag}");
        }
    }
}
