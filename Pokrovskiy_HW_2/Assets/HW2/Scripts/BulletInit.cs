using UnityEngine;


public class BulletInit : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    public static GameObject[] _bulletsTransformList;

    const byte STARTING_AMOUNT_OF_BULLETS = 4;
    const byte UPGRADE_AMOUNT_OF_BULLETS = 8;
    
    public static byte GetStartingAmountOfBullets {

        get { return STARTING_AMOUNT_OF_BULLETS;  }
    }  
    public static byte GetUpgradeAmountOfBullets {

        get { return UPGRADE_AMOUNT_OF_BULLETS;  }
    }

    private void Awake()
    {
        InitializeBullets(STARTING_AMOUNT_OF_BULLETS, gameObject, _bullet);
        UpdateBulletsPosition(STARTING_AMOUNT_OF_BULLETS, gameObject);
    }
    public static void InitializeBullets(byte amount, GameObject gameObject, GameObject bullet)
    {
        if (gameObject.transform.childCount > 0) {
            Transform[] childrenArray = gameObject.GetComponentsInChildren<Transform>();

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
            _bulletsTransformList[i].transform.SetParent(gameObject.transform);
            _bulletsTransformList[i].GetComponent<Rigidbody>().detectCollisions = false;
        }
    }

    public static void UpdateBulletsPosition(byte amount, GameObject gameObject)
    {
        for (byte i = 0; i < _bulletsTransformList.Length; i++)
        {
            Transform bulletTransform = _bulletsTransformList[i].transform;

            bulletTransform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);

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
}
