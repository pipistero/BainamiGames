using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Arrow : MonoBehaviour
{
    [Header("Physics")]
    [SerializeField] private Rigidbody2D _rigidbody;

    [Header("Animations")] 
    [SerializeField] private ArrowAnimationController _animationController;
    [SerializeField] private ArrowRotationController _rotationController;
    
    public void Launch(Vector3 startPosition, Vector2 velocity)
    {
        transform.position = startPosition;
        _rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy.IsDead) 
                return;
            
            OnArrowHit();
            enemy.Die();
        }
    }
    
    private void Update()
    {
        _rotationController.UpdateRotation(_rigidbody.velocity);
    }

    private void OnArrowHit()
    {
        _rigidbody.velocity = Vector2.zero;
        _animationController.PlayExplosionAnimation();
    }
}