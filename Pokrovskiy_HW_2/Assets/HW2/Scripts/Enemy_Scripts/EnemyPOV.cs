﻿using UnityEngine;


public class EnemyPOV : MonoBehaviour
{
    #region Fields

    [SerializeField] private LayerMask _mask;
    [SerializeField] private GameObject _rocketPrefab;

    [SerializeField] private float _distance;
    [SerializeField] private bool _drawGizmoRay = false;
    [SerializeField] private bool _turretMode = false;
    [SerializeField] private Vector3 _yOffset = Vector3.up * 0.5f;
    [SerializeField] private Vector3 _colliderPosition = Vector3.zero;
    [SerializeField] private Vector3 _colliderHalfDimentions = Vector3.zero;

    private GameObject _player;
    private RaycastHit _rayHit;
    private Color _gizmoRayColor = Color.red;
    private LineRenderer _laserRenderer;
    private Collider[] _collidersList;

    private Vector3 _rayStartPosition;
    private Vector3 _rayTargetPosition;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _laserRenderer = gameObject.GetComponent<LineRenderer>();
        _mask.value = LayerMask.NameToLayer("Everything");
    }

    private void FixedUpdate()
    {
        if (_turretMode) { TurretFindPlayer(); } else { EnemyFindPlayer(); }
    }

    #endregion

    #region Methods

    private void TurretFindPlayer()
    {
        _gizmoRayColor = Color.red;
        _rayStartPosition = gameObject.transform.position;
        _rayTargetPosition = _player.transform.position - gameObject.transform.position;

        _distance = 10f;

        _collidersList = Physics.OverlapBox(_colliderPosition, _colliderHalfDimentions);

        foreach (Collider collider in _collidersList)
        {
            if (collider.gameObject.CompareTag(_player.tag))
            {
                if (EnemyRayCast(_rayStartPosition, _rayTargetPosition, _rayTargetPosition.magnitude, _mask))
                {
                    if (_rayHit.collider.gameObject.CompareTag(_player.tag))
                    {
                        TurretActivate(true);

                        _gizmoRayColor = Color.green;
                    }
                    else
                    {
                        TurretActivate(false);
                    }
                }
                if (_drawGizmoRay) DrawGizmoRay(_rayStartPosition, _rayTargetPosition, _gizmoRayColor);
            }
        }
    }

    private void TurretActivate(bool activateTurret)
    {
        Vector3 turretLaserStart = gameObject.transform.position;
        Vector3 turretLaserTargetOffset = new Vector3(_distance, 0f, 0f);
        Vector3 turretLaserTarget = turretLaserStart + turretLaserTargetOffset;

        if (activateTurret) {
            _laserRenderer.startColor = Color.red;
            _laserRenderer.endColor = Color.red;
            _laserRenderer.SetPosition(0, turretLaserStart); 
            _laserRenderer.SetPosition(1, _player.transform.position);

            RocketLauncher.LaunchRocket(_rocketPrefab);
        }
        else
        {
            _laserRenderer.startColor = Color.green;
            _laserRenderer.endColor = Color.green;
            _laserRenderer.SetPosition(0, turretLaserStart);
            _laserRenderer.SetPosition(1, turretLaserTarget);
        }
    }

    private void EnemyFindPlayer() 
    {
        _gizmoRayColor = Color.red;
        _distance = 3.0f;

        _rayStartPosition = gameObject.transform.position + _yOffset;
        _rayTargetPosition = gameObject.transform.forward;

        if (EnemyRayCast(_rayStartPosition, _rayTargetPosition, _distance, _mask))
        {
            if (_rayHit.collider.gameObject.CompareTag(_player.tag))
            {
                _gizmoRayColor = Color.green;
                EnemyNavigation.EnemyFollowPlayer(gameObject);
            }
        }
        if (_drawGizmoRay) DrawGizmoRay(_rayStartPosition, _rayTargetPosition * _distance, _gizmoRayColor);
    }

    private void DrawGizmoRay(Vector3 startPos, Vector3 dir, Color color)
    {
        Debug.DrawRay(startPos, dir, color);
    }

    private bool EnemyRayCast(Vector3 startPos, Vector3 dir, float distance, LayerMask mask)
    {
        return Physics.Raycast(startPos, dir, out _rayHit, distance, mask);
    }

    #endregion
}
