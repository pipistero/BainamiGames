using UnityEngine;

public class ArrowRotationController : MonoBehaviour
{
    public void UpdateRotation(Vector2 velocity)
    {
        var zRotation = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        
        transform.localRotation = Quaternion.Euler(0f, 0f, zRotation);
    }
}