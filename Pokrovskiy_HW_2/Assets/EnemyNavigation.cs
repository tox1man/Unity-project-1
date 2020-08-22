using Boo.Lang;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNavigation : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _enemyNavigationAgent;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private bool _drawPaths;

    private int wayPointIndex = 0;
    private List<GameObject> _wayPointsList;
    private NavMeshAgent _enemyNavAgent;

    private void Start()
    {
        SetEnemyPatrol();
    }

    void Update()
    {
        //_enemyNavigationAgent.SetDestination(getPositionFromMouseButton());
        if (_drawPaths) DrawPaths();

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

    private void DrawPaths()
    {
        Color pathColor = new Color();
        //ПОДУМОЙ
        //pathColor.r = Mathf.Clamp(Mathf.Abs(gameObject.transform.parent.position.x) / 15, 0f, 1f);
        //pathColor.g = Mathf.Clamp(gameObject.transform.parent.position.y, 0f, 1f);
        //pathColor.b = Mathf.Clamp(Mathf.Abs(gameObject.transform.parent.position.z) / 15, 0f, 1f);
        Debug.Log(pathColor);
        pathColor.a = 1;

        for (int i = 0; i < _wayPointsList.Count - 1; i++)
        {
            Debug.DrawLine(_wayPointsList[i].transform.position, _wayPointsList[i + 1].transform.position, pathColor);
        }
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
