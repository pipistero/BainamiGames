using Spine;
using Spine.Unity;
using UnityEngine;

public class ArcherAnimationController : AbstractAnimationController
{
    [Header("Animations")] 
    [SerializeField] private AnimationReferenceAsset _idleAnimation;
    [SerializeField] private AnimationReferenceAsset _shootStartAnimation;
    [SerializeField] private AnimationReferenceAsset _shootTargetAnimation;
    [SerializeField] private AnimationReferenceAsset _shootFinishAnimation;

    [Header("Bones")] 
    [SerializeField, SpineBone(dataField: "_skeletonGraphic")] private string _gunBoneName;

    private Bone _gunBone;
    
    private void Start()
    {
        _gunBone = _skeletonGraphic.Skeleton.FindBone(_gunBoneName);
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

    public void SetRotation(float rotation)
    {
        _gunBone.Rotation = rotation;
    }
}