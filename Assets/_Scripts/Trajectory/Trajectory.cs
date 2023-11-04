using _Scripts.Extensions;
using UnityEngine;

public class Trajectory
{
    private const float TimeStep = 0.05f;

    public int PointsCount { get; } 
    public Vector3[] TrajectoryPoints { get; private set; }

    public Trajectory(int stepsCount)
    {
        PointsCount = stepsCount;
    }

    public void CreateTrajectory(Vector3 startPosition, Vector2 velocity)
    {
        TrajectoryPoints = new Vector3[PointsCount];
            
        for (int i = 0; i < PointsCount; i++)
        {
            float deltaTime = TimeStep * i;

            TrajectoryPoints[i] = CalculateTrajectoryPoint(startPosition, velocity, deltaTime);
        }
    }

    private Vector3 CalculateTrajectoryPoint(Vector3 startPosition, Vector2 velocity, float deltaTime)
    {
        return startPosition.AddVector2(velocity * deltaTime + Physics2D.gravity * (deltaTime * deltaTime) / 2);
    }
}