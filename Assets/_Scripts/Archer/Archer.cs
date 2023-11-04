using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Archer : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private ArcherInput _input;
    
    [Header("Animation")]
    [SerializeField] private ArcherAnimationController _animationController;
    [SerializeField] private ArcherRotationController _rotationController;

    [Header("Trajectory")] 
    [SerializeField] private TrajectoryDrawer _trajectoryDrawer;
    [SerializeField] private int _trajectoryPointCount;

    private Trajectory _trajectory;
    
    private void OnEnable()
    {
        _input.ShootStarted += OnShootStarted;
        _input.ShootContinued += OnShootContinued;
        _input.ShootFinished += OnShootFinished;
    }

    private void Start()
    {
        _trajectory = new Trajectory(_trajectoryPointCount);
    }

    private void OnShootStarted(Vector2 velocity)
    {
        _animationController.StartShootAnimation();
    }

    private void OnShootContinued(Vector2 velocity)
    {
        DrawTrajectory(velocity);
        _rotationController.SetRotation(Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg);
    }

    private void OnShootFinished(Vector2 velocity)
    {
        _animationController.FinishShootAnimation();
        
        _trajectoryDrawer.Clear();
    }
    
    private void DrawTrajectory(Vector2 velocity)
    {
        _trajectory.CreateTrajectory(transform.position, velocity);
        _trajectoryDrawer.Draw(_trajectory);
    }
    
    private void OnDisable()
    {
        _input.ShootStarted -= OnShootStarted;
        _input.ShootContinued -= OnShootContinued;
        _input.ShootFinished -= OnShootFinished;
    }
}