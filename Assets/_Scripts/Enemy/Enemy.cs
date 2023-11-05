using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [Header("Animations")] 
    [SerializeField] private EnemyAnimationController _animationController;

    [Header("Settings")] 
    [SerializeField] private float _reviveDelay;
    
    public bool IsDead { get; private set; }
    
    public async Task Die()
    {
        _animationController.PlayDeathAnimation();
        IsDead = true;

        await Task.Delay((int)(_reviveDelay * 1000));
        
        _animationController.PlayIdleAnimation();
        IsDead = false;
    }
}