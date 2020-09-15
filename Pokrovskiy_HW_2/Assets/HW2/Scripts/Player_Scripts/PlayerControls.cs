using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    private Rigidbody _player;
    
    private float _playerRotateSpeedMultiplier = 1.2f;
    private float _playerSpeed = 200.0f;

    private Vector3 _moveDirection;
 
    void Start()
    {
        _player = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveDirection = GetInput();
        
        if (Input.GetKeyDown(KeyCode.Space) && PlayerWeapon._isReloading == false)
        {
            PlayerWeapon.Shoot();
            PlayerWeapon.Reload();
            Invoke(nameof(InvokeFinishReload), PlayerWeapon._reloadTime);
        }
    }

    private void InvokeFinishReload()
    {
        PlayerWeapon.FinishReload();
    }

    private void FixedUpdate()
    {
        MovePlayer(_moveDirection);
    }

    private void LateUpdate()
    {
        PlayerWeapon.WeaponFollowPlayer();
    }

    private Vector3 GetInput()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
        dir.Normalize();
        return dir;
    }

    private void MovePlayer(Vector3 dir)
    {
        _player.velocity = dir * _playerSpeed * Time.fixedDeltaTime;
        _player.angularVelocity *= _playerRotateSpeedMultiplier;
    }
}

