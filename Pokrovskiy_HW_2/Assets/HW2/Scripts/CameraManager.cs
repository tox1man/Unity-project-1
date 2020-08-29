using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Transform _mainCameraTransform;
    private GameObject _playerGO;
    private Vector3 _mainCameraPos;
    // Start is called before the first frame update
    void Awake()
    {
        _playerGO = GameObject.FindGameObjectWithTag("Player");
        _mainCameraTransform = gameObject.GetComponent<Transform>();
        _mainCameraPos = _mainCameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _mainCameraPos = new Vector3(_playerGO.transform.position.x - 10f, _playerGO.transform.position.y + 15f, _playerGO.transform.position.z);
        _mainCameraTransform.position = _mainCameraPos;
    }
}
