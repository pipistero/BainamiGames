using Spine.Unity;
using UnityEngine;

public class ArrowAnimationController : AbstractAnimationController
{
    [Header("Animations")] 
    [SerializeField] private AnimationReferenceAsset _explosionAnimation;

    public void PlayExplosionAnimation()
    {
        SetAnimation(_explosionAnimation, false);
    }
}