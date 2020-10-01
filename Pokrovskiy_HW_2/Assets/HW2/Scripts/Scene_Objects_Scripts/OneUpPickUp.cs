using UnityEngine;


public class OneUpPickUp : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _weaponGameObject;

    private AudioSource _audioSource;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_player.CompareTag(other.gameObject.tag))
        {
            SoundManager.PlaySound("OneUpSound");
            gameObject.GetComponent<Renderer>().enabled = false;

            BulletInit.InitializeBullets(BulletInit.GetUpgradeAmountOfBullets, _bulletPrefab, _weaponGameObject);
            BulletInit.UpdateBulletsPosition(BulletInit.GetUpgradeAmountOfBullets, _weaponGameObject);

            Invoke(nameof(DestroyPickUp), 0.5f);

        }
    }
    
    private void DestroyPickUp()
    {
        Destroy(gameObject);
    }
}
