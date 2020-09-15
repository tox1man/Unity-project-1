using UnityEngine;


public class OneUpPickUp : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _weaponGameObject;
    Material bulletMaterial;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_player.CompareTag(other.gameObject.tag))
        {
            BulletInit.InitializeBullets(BulletInit.GetUpgradeAmountOfBullets, _bulletPrefab, _weaponGameObject);
            BulletInit.UpdateBulletsPosition(BulletInit.GetUpgradeAmountOfBullets, _weaponGameObject);

            Destroy(gameObject);
        }
    }
}
