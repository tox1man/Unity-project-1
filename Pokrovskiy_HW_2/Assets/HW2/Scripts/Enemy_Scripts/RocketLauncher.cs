using UnityEngine;


public class RocketLauncher : MonoBehaviour
{
    private static float _rocketSpeed = 100.0f;
    private static GameObject _rocket;
    private static GameObject _turret;
    private static GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _turret = gameObject;
    }
    public static void LaunchRocket(GameObject rocket)
    {
        if (_rocket == null)
        {
            _rocket = Instantiate(rocket, _turret.transform.position, _turret.transform.rotation);
            _rocket.transform.SetParent(_turret.transform);
        }
        Destroy(_rocket, 4);
    }

    private static void RocketSeekTarget(GameObject target)
    {
        _rocket.transform.LookAt(target.transform);
        _rocket.GetComponent<Rigidbody>().AddForce(_rocket.transform.up * _rocketSpeed * Time.fixedDeltaTime, ForceMode.Force);
    }

    private void FixedUpdate()
    {
        if (_rocket != null) { RocketSeekTarget(_player); }
    }
}
