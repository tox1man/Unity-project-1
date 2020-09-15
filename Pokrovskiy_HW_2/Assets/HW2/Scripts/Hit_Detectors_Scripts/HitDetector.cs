using UnityEngine;

public class HitDetector : MonoBehaviour
{
    #region Fields

    private bool _playerHitDetector = false;
    private bool _bulletHitDetector = false;
    private static bool _playerHit = false;

    //EnemyKillManager killManager;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _playerHitDetector = gameObject.CompareTag("Player");
        _bulletHitDetector = gameObject.CompareTag("Bullet");
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (_playerHitDetector) CheckPlayerHit(coll, _playerHit, gameObject);
        else if (_bulletHitDetector) CheckBulletHit(coll, gameObject);
    }

    #endregion

    #region BulletMethods

    public static void CheckBulletHit(Collider coll, GameObject bullet)
    {
        if (coll.gameObject.CompareTag("Enemy"))
        {
            EnemyKillManager.KillEnemy(coll.gameObject);
            Destroy(bullet);
        }
        else if (!coll.gameObject.CompareTag("Enemy") && !coll.gameObject.CompareTag("Bullet"))
        {
            Destroy(bullet);
        }
    }

    #endregion

    #region PlayerMethods

    public static void CheckPlayerHit(Collider coll, bool playerHit, GameObject player)
    {

        if (coll.gameObject.CompareTag("Enemy"))
        {
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
