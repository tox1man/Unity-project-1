using UnityEngine;


public class BulletInit : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] public Material _tempBulletMaterial;
    public static GameObject[] _bulletsTransformList;

    private const byte STARTING_AMOUNT_OF_BULLETS = 4;
    const byte UPGRADE_AMOUNT_OF_BULLETS = 8;
    
    public static byte GetStartingAmountOfBullets {

        get { return STARTING_AMOUNT_OF_BULLETS;  }
    }  
    public static byte GetUpgradeAmountOfBullets {

        get { return UPGRADE_AMOUNT_OF_BULLETS;  }
    }
    //public static Material GetBulletMaterial
    //{

    //    get { return new BulletInit()._tempBulletMaterial; }
    //}

    private void Awake()
    {
        InitializeBullets(STARTING_AMOUNT_OF_BULLETS, gameObject, _bullet, _tempBulletMaterial);
        UpdateBulletsPosition(STARTING_AMOUNT_OF_BULLETS, gameObject);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="gameObject">Parent object (weapon)</param>
    /// <param name="bullet"></param>
    public static void InitializeBullets(byte amount, GameObject parent, GameObject bullet, Material material)
    {
        if (parent.transform.childCount > 0) {
            Transform[] childrenArray = parent.GetComponentsInChildren<Transform>();

            foreach (Transform child in childrenArray)
            {
                if (child.gameObject.CompareTag("Bullet")) {
                    Destroy(child.gameObject);
                }
            }
        }

        _bulletsTransformList = new GameObject[amount];

        for (byte i = 0; i < _bulletsTransformList.Length; i++)
        {
            _bulletsTransformList[i] = Instantiate<GameObject>(bullet);

            _bulletsTransformList[i].transform.SetParent(parent.transform);
            _bulletsTransformList[i].GetComponent<Rigidbody>().detectCollisions = false;
        }
    }

    public static void UpdateBulletsPosition(byte amount, GameObject weapon)
    {
        for (byte i = 0; i < _bulletsTransformList.Length; i++)
        {
            Transform bulletTransform = _bulletsTransformList[i].transform;

            bulletTransform.position = new Vector3(weapon.transform.position.x, 0, weapon.transform.position.z);

            bulletTransform.Rotate(0f, (360 / amount) * i, 0f, Space.World);

            bulletTransform.Translate(0f, 1f, 0f, Space.Self);
            bulletTransform.Translate(0f, 0.8f, 0f, Space.World);
        }
    }

    public static GameObject[] GetBulletsList()
    {
        try
        {
            if (_bulletsTransformList.Length != 0)
            {
                return _bulletsTransformList;
            }
        }
        catch
        {
            throw new System.Exception("Error");
        }
        return null;
    }

    public static void SetBulletMaterial(GameObject bullet, Material material)
    {
        bullet.GetComponent<Renderer>().material = material;
    }
}
