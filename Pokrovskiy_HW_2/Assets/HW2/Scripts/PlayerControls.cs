using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 100f;
    [SerializeField] private float _playerRotateSpeedMultiplier = 1.5f;
    [SerializeField] private float _shotPower = 20f;
    [SerializeField] private GameObject _weapon;
    [SerializeField] private GameObject _bulletsContainer;
    private GameObject[] _bullets;
    private Rigidbody playerRB;
    
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
        _bullets = BulletInit.GetBulletsList();
        Debug.Log(_bullets.Length);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        MovePlayer(GetInput());
    }

    private Vector3 GetInput()
    {
        return new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
    }

    void MovePlayer(Vector3 speed)
    {
        playerRB.velocity = speed * _playerSpeed * Time.fixedDeltaTime;
        _weapon.transform.position = gameObject.transform.position;
        playerRB.angularVelocity *= _playerRotateSpeedMultiplier;
    }
    
    void Shoot()
    {
        //bool isShot = false;
        foreach (GameObject bullet in _bullets)
        {
            //Debug.Log(bullet);
            var tempBullet = Instantiate<GameObject>(bullet, bullet.transform.position, bullet.transform.rotation);
            tempBullet.transform.SetParent(_bulletsContainer.transform, true);
            tempBullet.GetComponent<Collider>().isTrigger = true;
            tempBullet.GetComponent<Rigidbody>().isKinematic = false;

            tempBullet.GetComponent<Rigidbody>().AddForce(tempBullet.transform.up * _shotPower, ForceMode.Impulse);
        }
    }
}

