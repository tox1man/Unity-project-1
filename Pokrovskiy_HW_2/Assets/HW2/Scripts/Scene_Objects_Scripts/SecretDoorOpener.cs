using UnityEngine;


public class SecretDoorOpener : MonoBehaviour
{
    private GameObject _player;
    private GameObject _secretDoor;
    private Collider _playerCollider;
    private Collider _doorCollider;
    private ParticleSystem _doorParticleSystem;
    private Renderer _doorRenderer;

    private bool _isOpen = false;
    

    void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _secretDoor = GameObject.Find("SecretDoor");

        _playerCollider = _player.GetComponent<Collider>();

        _doorParticleSystem = _secretDoor.GetComponent<ParticleSystem>();
        _doorRenderer = _secretDoor.GetComponent<Renderer>();
        _doorCollider = _secretDoor.GetComponent<Collider>();

        _doorParticleSystem.Pause();
    }

    private void OnTriggerEnter(Collider _playerCollider)
    {
        if(!_isOpen) SecretDoorOpen();
    }

    private void SecretDoorOpen()
    {
        _doorParticleSystem.Play();
        _doorRenderer.enabled = _isOpen;
        _doorCollider.enabled = _isOpen;

        _isOpen = !_isOpen;
        ButtonAnimator.AnimateButton();
    }
}
