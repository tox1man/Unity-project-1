using UnityEngine;


public class CameraManager : MonoBehaviour
{
    private Transform _mainCameraTransform;
    private Transform _playerTransform;

    public static Vector3 _cameraOffset;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        _mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        _cameraOffset = new Vector3(-10.0f, 15.0f, 0.0f);
    }

    private void Update()
    {
        MainCameraFollowPlayer();
    }

    public static void SetActiveCamera(string cameraTag)
    {
        Camera camera = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
        camera.enabled = true;
    }

    public static void DeactivateCamera(string cameraTag)
    {
        Camera camera = GameObject.FindGameObjectWithTag(cameraTag).GetComponent<Camera>();
        camera.enabled = false;
    }

    private void MainCameraFollowPlayer()
    {
        _mainCameraTransform.position = _playerTransform.position + _cameraOffset;
    }
}
