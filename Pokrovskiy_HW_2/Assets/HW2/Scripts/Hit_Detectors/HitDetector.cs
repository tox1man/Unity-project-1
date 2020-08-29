using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    #region Fields

    bool _playerHitDetector = false;
    bool _bulletHitDetector = false;
    private static bool _playerHit = false;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _playerHitDetector = gameObject.CompareTag("Player");
        _bulletHitDetector = gameObject.CompareTag("Bullet");
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (_playerHitDetector) { CheckPlayerHit(coll, _playerHit, gameObject); }
        else if (_bulletHitDetector) { CheckBulletHit(coll, gameObject); }
        //else { throw new Exception("No Collider object is set at HitDetector.cs"); }
    }

    #endregion

    #region BulletMethods

    public static void CheckBulletHit(Collider coll, GameObject enemy)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Destroy(enemy);
            Destroy(coll.gameObject);

            Debug.Log($"Bullet hit {coll.gameObject.tag}");
        }
        else if (!coll.gameObject.CompareTag("Enemy") && !coll.gameObject.CompareTag("Bullet"))
        {
            Destroy(enemy);

            Debug.Log($"Bullet hit {coll.gameObject.tag}");
        }
    }

    #endregion

    #region PlayerMethods

    public static void CheckPlayerHit(Collider coll, bool playerHit, GameObject player)
    {

        if (coll.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Hit by {coll.gameObject.tag}");

            if (playerHit)
            {
                HitDetector.KillPlayer(player);
            }
            else
            {
                _playerHit = true;
            }
        }
        else if (coll.gameObject.CompareTag("Rocket"))
        {
            HitDetector.KillPlayer(player);
            Destroy(coll.gameObject);
        }
    }
    private static void KillPlayer(GameObject player)
    {
        player.SetActive(false);

        Debug.Log("You died!");
    }

    #endregion
}
