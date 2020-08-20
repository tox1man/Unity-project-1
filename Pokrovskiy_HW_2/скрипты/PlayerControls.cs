using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 100f;
    private Vector3 _inGameSpeed;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    private void Update()
    {
        playerRB.velocity = _inGameSpeed = new Vector3(Input.GetAxisRaw("Vertical") * -_playerSpeed * Time.fixedDeltaTime, playerRB.velocity.y, Input.GetAxisRaw("Horizontal") * _playerSpeed * Time.fixedDeltaTime);
    }
}
