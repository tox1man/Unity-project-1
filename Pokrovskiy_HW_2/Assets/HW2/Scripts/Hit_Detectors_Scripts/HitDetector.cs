using UnityEngine;

public class HitDetector : MonoBehaviour
{
    #region Fields

    private GameObject _weapon;
    private static AudioSource _audioSource;
    private static ParticleSystem _particleSystem;

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

        _audioSource = GameObject.Find("BulletHitSound").GetComponent<AudioSource>();
        _particleSystem = gameObject.GetComponent<ParticleSystem>();
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

            SoundManager.PlaySound("BulletHitSound");
            PlayHitParticleAnimation(bullet);

            bullet.GetComponent<Rigidbody>().Sleep();
            bullet.GetComponent<Renderer>().enabled = false;
        }
        else if (!coll.gameObject.CompareTag("Enemy") && !coll.gameObject.CompareTag("Bullet"))
        {
            PlayHitParticleAnimation(bullet);

            bullet.GetComponent<Rigidbody>().Sleep();
            bullet.GetComponent<Renderer>().enabled = false;
        }
    }

    private static void PlayHitParticleAnimation(GameObject bullet)
    {
        bullet.GetComponent<ParticleSystem>().Play();
    }

    #endregion

    #region PlayerMethods

    public static void CheckPlayerHit(Collider coll, bool playerHit, GameObject player, GameObject weapon)
    {

        if (coll.gameObject.CompareTag("Enemy"))
        {
            if (playerHit)
            {
                SoundManager.PlaySound("PlayerHitSound");
                HitDetector.KillPlayer(player, weapon);
            }
            else
            {
                SoundManager.PlaySound("PlayerHitSound");
                _playerHit = true;
            }
        }
        else if (coll.gameObject.CompareTag("Rocket"))
        {
            SoundManager.PlaySound("PlayerHitSound");
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
