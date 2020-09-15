using UnityEngine;


public class BulletInit : MonoBehaviour
{
    [SerializeField] public GameObject _bulletPrefab;
    [SerializeField] private Material _tempBulletMaterial;
    [SerializeField] public GameObject _weapon;
    public static GameObject[] _bulletsTransformList;

    private const byte STARTING_AMOUNT_OF_BULLETS = 4;
    const byte UPGRADE_AMOUNT_OF_BULLETS = 8;
    
    public static byte GetStartingAmountOfBullets {

        get { return STARTING_AMOUNT_OF_BULLETS;  }
    }  
    public static byte GetUpgradeAmountOfBullets {

        get { return UPGRADE_AMOUNT_OF_BULLETS;  }
    }
    private void Start()
    {
        //_weapon = GameObject.FindGameObjectWithTag("Weapon");

        InitializeBullets(STARTING_AMOUNT_OF_BULLETS, _bulletPrefab, _weapon);
        UpdateBulletsPosition(STARTING_AMOUNT_OF_BULLETS, _weapon);
    }
    /// <summary>
    /// Adds a set amount of bullets to player weapon
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="bulletGameObject">Parent object (weapon)</param>
    /// <param name="weaponGameObject"></param>
    public static void InitializeBullets(byte amount, GameObject bulletPrefab, GameObject weaponPrefab)
    {
        if (weaponPrefab.transform.childCount > 0)
        {
            Transform[] childrenArray = weaponPrefab.GetComponentsInChildren<Transform>();

            foreach (Transform child in childrenArray)
            {
                if (child.gameObject.CompareTag("Bullet"))
                {
                    Destroy(child.gameObject);
                }
            }
        }

        _bulletsTransformList = new GameObject[amount];

        for (byte i = 0; i < _bulletsTransformList.Length; i++)
        {
            _bulletsTransformList[i] = Instantiate<GameObject>(bulletPrefab);

            _bulletsTransformList[i].transform.SetParent(weaponPrefab.transform);
            _bulletsTransformList[i].GetComponent<Rigidbody>().detectCollisions = false;
        }
    }

    public static void UpdateBulletsPosition(byte amount, GameObject weaponPrefab)
    {
        for (byte i = 0; i < _bulletsTransformList.Length; i++)
        {
            Transform bulletTransform = _bulletsTransformList[i].transform;

            bulletTransform.position = new Vector3(weaponPrefab.transform.position.x, 0.0f, weaponPrefab.transform.position.z);

            bulletTransform.Rotate(0.0f, (360.0f / amount) * i, 0.0f, Space.World);

            bulletTransform.Translate(Vector3.up, Space.Self);
            bulletTransform.Translate(Vector3.up * 0.8f, Space.World);
        }
    }

    public static GameObject[] GetBulletsList()
    {
        return _bulletsTransformList;
    }

    public static void SetBulletMaterial(GameObject bullet, Material material)
    {
        bullet.GetComponent<Renderer>().material = material;
    }
}
