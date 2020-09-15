using System;
using System.Collections;
using UnityEngine;


public class PlayerWeapon : MonoBehaviour
{
    private static GameObject _bulletsContainer;

    private static GameObject _weapon;
    private static GameObject _player;
    private static GameObject[] _bullets;

    private static float _shotPower = 20.0f;
    public static float _reloadTime = 1.0f;
    public static bool _isReloading = false;

    private static Color reloadColor = new Color(1f, 0.3f, 0.3f, 1f);
    private static Color readyColor = new Color(0.6f, 0.3f, 1f, 1f);


    private void Start()
    {
        _weapon = GameObject.FindGameObjectWithTag("Weapon");
        _player = GameObject.FindGameObjectWithTag("Player");

        _bullets = BulletInit.GetBulletsList();

        _bulletsContainer = GameObject.FindGameObjectWithTag("BulletContainer");
    }

    public static void WeaponFollowPlayer()
    {
        _weapon.transform.position = _player.transform.position;
    }

    public static void Shoot()
    {
        if (_isReloading) return;

        _bullets = BulletInit.GetBulletsList();

        foreach (GameObject bullet in _bullets)
        {
            var tempBullet = Instantiate<GameObject>(bullet, bullet.transform.position, bullet.transform.rotation);
            tempBullet.transform.SetParent(_bulletsContainer.transform, true);
            tempBullet.GetComponent<Collider>().isTrigger = true;
            tempBullet.GetComponent<Rigidbody>().isKinematic = false;

            tempBullet.GetComponent<Rigidbody>().AddForce(tempBullet.transform.up * _shotPower, ForceMode.Impulse);
        }
    }

    public static void Reload()
    {
        _isReloading = true;
        SetBulletColor(reloadColor);
    }

    public static void FinishReload()
    {
        _isReloading = false;
        SetBulletColor(readyColor);
    }

    private static void SetBulletColor(Color transparentColor)
    {
        foreach (GameObject bullet in _bullets)
        {
            bullet.GetComponent<Renderer>().material.color = transparentColor;
        }
    }
}
