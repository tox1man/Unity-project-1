using UnityEngine;

public class HitDetector : MonoBehaviour
{
    #region Fields

    private GameObject _weapon;

    public static bool _playerHit = false;
    private bool _playerHitDetector = false;
    private bool _bulletHitDetector = false;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _weapon = GameObject.FindGameObjectWithTag("Weapon");

        _playerHitDetector = gameObject.CompareTag("Player");
        _bulletHitDetector = gameObject.CompareTag("Bullet");
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (_playerHitDetector) CheckPlayerHit(coll, _playerHit, gameObject, _weapon);
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

    public static void CheckPlayerHit(Collider coll, bool playerHit, GameObject player, GameObject weapon)
    {

        if (coll.gameObject.CompareTag("Enemy"))
        {
            if (playerHit)
            {
                HitDetector.KillPlayer(player, weapon);
            }
            else
            {
                _playerHit = true;
            }
        }
        else if (coll.gameObject.CompareTag("Rocket"))
        {
            HitDetector.KillPlayer(player,weapon);
            Destroy(coll.gameObject);
        }
    }
    private static void KillPlayer(GameObject player, GameObject weapon)
    {
        player.SetActive(false);
        weapon.SetActive(false);

        GameManager.LoseGame();
    }

    #endregion
}
