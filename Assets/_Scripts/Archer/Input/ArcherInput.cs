using System;
using UnityEngine;

public class ArcherInput : MonoBehaviour
{
    public event Action<Vector2> ShootStarted; 
    public event Action<Vector2> ShootContinued;
    public event Action<Vector2> ShootFinished;

    [Header("Settings")]
    [SerializeField] private Vector2 _maxVelocity;
    [SerializeField, Range(0f, 2f)] private float _velocityMultiplier;
    
    private Vector3 _startMousePosition;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startMousePosition = Input.mousePosition;
            
            ShootStarted?.Invoke(GetShootVelocity());
        }

        if (Input.GetMouseButton(0))
        {
            ShootContinued?.Invoke(GetShootVelocity());
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            ShootFinished?.Invoke(GetShootVelocity());
        }
    }

    private Vector2 GetShootVelocity()
    {
        var velocity = _startMousePosition - Input.mousePosition;
        var clampedVelocity = velocity.Clamp(_maxVelocity * -1f, _maxVelocity);
        var shootVelocity = clampedVelocity * _velocityMultiplier;
        
        return shootVelocity;
    }
}