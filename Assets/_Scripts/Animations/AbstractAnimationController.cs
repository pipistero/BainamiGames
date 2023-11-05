using Spine.Unity;
using UnityEngine;

public abstract class AbstractAnimationController : MonoBehaviour
{
    [Header("Skeleton")] 
    [SerializeField] protected SkeletonGraphic _skeletonGraphic;
    
    protected void SetAnimation(AnimationReferenceAsset animationAsset, bool isLoop)
    {
        _skeletonGraphic.AnimationState.SetAnimation(0, animationAsset, isLoop);
    }

    protected void AddAnimation(AnimationReferenceAsset animationAsset, bool isLoop, float delay)
    {
        _skeletonGraphic.AnimationState.AddAnimation(0, animationAsset, isLoop, delay);
    }

    protected float GetAnimationDuration(AnimationReferenceAsset animationAsset)
    {
        return animationAsset.Animation.Duration;
    }
}