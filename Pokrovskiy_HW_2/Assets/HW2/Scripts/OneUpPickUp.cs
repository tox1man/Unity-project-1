using UnityEngine;


public class OneUpPickUp : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _bullet;

    private Collider _playerCollider;

    void Awake()
    {
        _playerCollider = _player.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider _playerCollider)
    {
        Debug.Log("One up!");
        BulletInit.InitializeBullets(BulletInit.GetUpgradeAmountOfBullets, _weapon, _bullet);
        BulletInit.UpdateBulletsPosition(BulletInit.GetUpgradeAmountOfBullets, _weapon);
        Destroy(gameObject);
    }
}
