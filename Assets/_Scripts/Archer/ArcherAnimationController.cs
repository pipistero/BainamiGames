using Spine.Unity;
using UnityEngine;
using UnityEngine.Serialization;

public class ArcherAnimationController : MonoBehaviour
{
    [Header("Skeleton")] 
    [SerializeField] private SkeletonGraphic _skeletonGraphic;
    
    [Header("Animations")] 
    [SerializeField] private AnimationReferenceAsset _idleAnimation;
    [SerializeField] private AnimationReferenceAsset _deathAnimation;
    [SerializeField] private AnimationReferenceAsset _shootStartAnimation;
    [SerializeField] private AnimationReferenceAsset _shootTargetAnimation;
    [SerializeField] private AnimationReferenceAsset _shootFinishAnimation;
    
    public void PlayIdleAnimation()
    {
        SetAnimation(_idleAnimation, true);
    }
    
    public void StartShootAnimation()
    {
        SetAnimation(_shootStartAnimation, false);
        AddAnimation(_shootTargetAnimation, true, GetAnimationDuration(_shootStartAnimation));
    }

    public void FinishShootAnimation()
    {
        SetAnimation(_shootFinishAnimation, false);
        AddAnimation(_idleAnimation, true, GetAnimationDuration(_shootFinishAnimation));
    }

    public void PlayDeathAnimation()
    {
        SetAnimation(_deathAnimation, false);
    }

    private void SetAnimation(AnimationReferenceAsset animation, bool isLoop)
    {
        _skeletonGraphic.AnimationState.SetAnimation(0, animation, isLoop);
    }

    private void AddAnimation(AnimationReferenceAsset animation, bool isLoop, float delay)
    {
        _skeletonGraphic.AnimationState.AddAnimation(0, animation, isLoop, delay);
    }

    private float GetAnimationDuration(AnimationReferenceAsset animation)
    {
        return animation.Animation.Duration;
    }
}