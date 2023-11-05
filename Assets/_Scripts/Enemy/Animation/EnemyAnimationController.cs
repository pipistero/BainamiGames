using Spine.Unity;
using UnityEngine;

public class EnemyAnimationController : AbstractAnimationController
{
    [Header("Animations")] 
    [SerializeField] private AnimationReferenceAsset _idleAnimation;
    [SerializeField] private AnimationReferenceAsset _deathAnimation;

    public void PlayDeathAnimation()
    {
        SetAnimation(_deathAnimation, false);
    }

    public void PlayIdleAnimation()
    {
        SetAnimation(_idleAnimation, true);
    }
}