using UnityEngine;


public class OneUpPickUp : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _bullet;
    Material bulletMaterial;

    void Awake()
    {
        bulletMaterial = new Material(new BulletInit()._tempBulletMaterial);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_player.CompareTag(other.gameObject.tag))
        {
            Debug.Log("One up!");
            BulletInit.InitializeBullets(BulletInit.GetUpgradeAmountOfBullets, _weapon, _bullet, bulletMaterial);
            BulletInit.UpdateBulletsPosition(BulletInit.GetUpgradeAmountOfBullets, _weapon);

            Destroy(gameObject);
        }
    }
}
