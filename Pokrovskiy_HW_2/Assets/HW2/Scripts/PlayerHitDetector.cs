using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitDetector : MonoBehaviour
{
    private bool _playerHit = false;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"Hit by {coll.gameObject.tag}");

            if (_playerHit)
            {
                KillPlayer();
            }
            else
            {
                _playerHit = true;
            }
        }
    }

    private void KillPlayer()
    {
        gameObject.SetActive(false);
        Debug.Log("You died!");
    }
}
