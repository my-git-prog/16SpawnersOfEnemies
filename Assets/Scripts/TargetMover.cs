using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private List<TargetRoutePoint> _routePoints;
    [SerializeField] private float _routePointDestinationMagnitude = 2f;
    [SerializeField] private float _speed = 2f;

    private int _currentRoutePointIndex = 0;

    private void Start()
    {
        RotateToCurrentRoutePoint();
    }

    private void Update()
    {
        if (IsNearRoutePoint())
        {
            _currentRoutePointIndex = (++_currentRoutePointIndex) % _routePoints.Count;
            RotateToCurrentRoutePoint();
        }

        MoveToCurrentRoutePoint();
    }

    private void RotateToCurrentRoutePoint()
    {
        transform.LookAt(_routePoints[_currentRoutePointIndex].transform.position);
    }

    private void MoveToCurrentRoutePoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, _routePoints[_currentRoutePointIndex].transform.position, _speed * Time.deltaTime);
    }

    private bool IsNearRoutePoint()
    {
        return (transform.position - _routePoints[_currentRoutePointIndex].transform.position).magnitude < _routePointDestinationMagnitude;
    }
}
