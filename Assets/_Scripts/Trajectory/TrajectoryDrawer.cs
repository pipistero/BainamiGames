using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryDrawer : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject _pointPrefab;
    
    [Header("Holder")]
    [SerializeField] private Transform _pointsHolder;

    [Header("Settings")] 
    [SerializeField] private Vector3 _startPointScale;
    [SerializeField] private Vector3 _endPointScale;
    
    private readonly List<GameObject> _trajectoryPoints = new List<GameObject>();

    public void Draw(Trajectory trajectory)
    {
        int pointsLength = trajectory.PointsCount;

        if (_trajectoryPoints.Count != pointsLength)
            PreparePoints(pointsLength);
        
        for (int i = 0; i < pointsLength; i++)
        {
            var point = _trajectoryPoints[i];
            var pointScale = Vector3.Lerp(_startPointScale, _endPointScale, (float)i / (pointsLength - 1));

            point.transform.position = trajectory.TrajectoryPoints[i];
            point.transform.localScale = pointScale;
            
            _trajectoryPoints.Add(point);
        }
    }

    public void Clear()
    {
        _trajectoryPoints.ForEach(Destroy);
        _trajectoryPoints.Clear();
    }

    private void PreparePoints(int pointsCount)
    {
        for (int i = _trajectoryPoints.Count; i < pointsCount; i++)
        {
            _trajectoryPoints.Add(CreatePoint());
        }
    }

    private GameObject CreatePoint()
    {
        return Instantiate(_pointPrefab, _pointsHolder);
    }
}
