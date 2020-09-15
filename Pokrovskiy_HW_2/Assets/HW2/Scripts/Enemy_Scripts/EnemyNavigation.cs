//using Boo.Lang;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemyNavigationAgent;
    [SerializeField] private bool _drawPaths = false;
    private Camera _mainCamera;

    private int wayPointIndex = 0;
    private List<GameObject> _wayPointsList;
    private NavMeshAgent _enemyNavAgent;
    private Color pathColor;

    private void Awake()
    {
        _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Start()
    {
        SetEnemyPatrol();
        pathColor = GenerateRandomColor();
    }

    private void Update()
    {
        if (_drawPaths) DrawPaths(pathColor);

        if (_enemyNavAgent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    private List<GameObject> GetEnemyWayPoints()
    {
        Transform parentTransform = gameObject.transform.parent;
        List<GameObject> _enemyWayPoints = new List<GameObject>();

        for (int i = 0; i < parentTransform.childCount; i++)
        {
            if (parentTransform.GetChild(i).CompareTag("WayPoint"))
            {
                GameObject wayPoint = parentTransform.GetChild(i).gameObject;
                _enemyWayPoints.Add(wayPoint);
            }
        }
        //Debug.Log(_enemyWayPoints.Count);
        return _enemyWayPoints;
    }

    private void SetEnemyPatrol()
    {
        _wayPointsList = GetEnemyWayPoints();
        _enemyNavAgent = gameObject.GetComponent<NavMeshAgent>();

        _enemyNavAgent.autoBraking = false;
        GoToNextPoint();
    }

    private void DrawPaths(Color color)
    {
        for (int i = 0; i < _wayPointsList.Count - 1; i++)
        {
            Debug.DrawLine(_wayPointsList[i].transform.position, _wayPointsList[i + 1].transform.position, color);
        }
    }

    private Color GenerateRandomColor()
    {
        return UnityEngine.Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }

    private void GoToNextPoint()
    {
        if (_wayPointsList.Count == 0) return;

        _enemyNavAgent.SetDestination(_wayPointsList[wayPointIndex].transform.position);
        wayPointIndex = (wayPointIndex + 1) % _wayPointsList.Count;
        //Debug.Log(wayPointIndex);
    }

    private Vector3 getPositionFromMouseButton()
    {
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        try
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                //Debug.Log(ray.origin);
                return hit.point;
            }
        }
        catch
        {
            throw new System.Exception("Error returning Vector3 from raycasting");
        }
        return Vector3.zero;
    }
}
