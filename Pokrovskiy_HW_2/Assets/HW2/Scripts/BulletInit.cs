using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class BulletInit : MonoBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private uint _amountOfBullets = 8;
    public static GameObject[] _bulletsTransformList;

    private void Awake()
    {
        InitializeBullets(_amountOfBullets);
        UpdateBulletsPosition();
    }
    void Start()
    {
    }

    private void InitializeBullets(uint amount)
    {
        _bulletsTransformList = new GameObject[amount];
        for (uint i = 0; i < _bulletsTransformList.Length; i++)
        {
            _bulletsTransformList[i] = Instantiate<GameObject>(_bullet);
            _bulletsTransformList[i].transform.SetParent(gameObject.transform);
            _bulletsTransformList[i].GetComponent<Rigidbody>().detectCollisions = false;
            
        }
    }

    private void UpdateBulletsPosition()
    {
        for (uint i = 0; i < _bulletsTransformList.Length; i++)
        {
            Transform bulletTransform = _bulletsTransformList[i].transform;

            bulletTransform.position = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);

            bulletTransform.Rotate(0f, (360 / _amountOfBullets) * i, 0f, Space.World);

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

    // Update is called once per frame
    void Update()
    {
        //UpdateBulletsPosition();
    }
}
