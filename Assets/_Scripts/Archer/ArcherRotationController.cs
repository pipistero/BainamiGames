using Spine;
using Spine.Unity;
using UnityEngine;

public class ArcherRotationController : MonoBehaviour
{
    [Header("Skeleton")]
    [SerializeField] private SkeletonGraphic _skeletonGraphic;
    
    [Header("Bone")]
    [SerializeField, SpineBone(dataField:"_skeletonGraphic")] private string _boneName;

    private Bone _bone;

    private void Start()
    {
        _bone = _skeletonGraphic.Skeleton.FindBone(_boneName);
    }

    public void SetRotation(float rotation)
    {
        _bone.Rotation = rotation;
    }
}