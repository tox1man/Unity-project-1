using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _bulletsContainer;
    private GameObject[] _bullets;
    private Rigidbody _playerRB;
    private Material _tempBulletMaterial;

    [SerializeField] private float _playerRotateSpeedMultiplier = 1.5f;
    [SerializeField] private float _playerSpeed = 100f;

    [SerializeField] private float _shotPower = 200f;
    [SerializeField] private float _reloadTime = 1.0f;
    private bool _isReloading = false;

    private Vector3 _moveDirection;
    Color reloadColor = new Color(1f, 0.3f, 0.3f, 1f);
    Color readyColor = new Color(0.6f, 0.3f, 1f, 1f);

    void Start()
    {
        _playerRB = gameObject.GetComponent<Rigidbody>();

        _tempBulletMaterial = new BulletInit()._tempBulletMaterial;
        _bullets = BulletInit.GetBulletsList();
        Debug.Log(_bullets.Length);
    }

    private void Update()
    {
        _moveDirection = GetInput();
        
        if (Input.GetKeyDown(KeyCode.Space) && !_isReloading)
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        MovePlayer(_moveDirection);

    }

    private Vector3 GetInput()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
        dir.Normalize();
        return dir;
    }

    private void MovePlayer(Vector3 speed)
    {
        _playerRB.velocity = speed * _playerSpeed * Time.fixedDeltaTime;
        _weapon.transform.position = gameObject.transform.position;
        _playerRB.angularVelocity *= _playerRotateSpeedMultiplier;
    }

    private void Shoot()
    {
        _bullets = BulletInit.GetBulletsList();

        foreach (GameObject bullet in _bullets)
        {
            //Debug.Log(bullet);
            var tempBullet = Instantiate<GameObject>(bullet, bullet.transform.position, bullet.transform.rotation);
            tempBullet.transform.SetParent(_bulletsContainer.transform, true);
            tempBullet.GetComponent<Collider>().isTrigger = true;
            tempBullet.GetComponent<Rigidbody>().isKinematic = false;

            tempBullet.GetComponent<Rigidbody>().AddForce(tempBullet.transform.up * _shotPower, ForceMode.Impulse);

            BulletInit.SetBulletMaterial(bullet, _tempBulletMaterial);
        }
        Reload();
        Invoke("FinishReload", _reloadTime);
    }

    private void Reload()
    {
        _isReloading = true;
        SetBulletColor(reloadColor);
    }

    private void FinishReload()
    {
        _isReloading = false;
        SetBulletColor(readyColor);
    }

    private void SetBulletColor(Color transparentColor)
    {
        foreach (GameObject bullet in _bullets)
        {
            bullet.GetComponent<Renderer>().material.color = transparentColor;
        }
    }
}

