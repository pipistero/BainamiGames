using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    [Header("Prefab")] 
    [SerializeField] private Arrow _arrowPrefab;

    [Header("Holder")] 
    [SerializeField] private Transform _arrowsHolder;

    public void Launch(Vector3 startPosition, Vector2 velocity)
    {
        var arrow = Instantiate(_arrowPrefab, _arrowsHolder);
            
        arrow.Launch(startPosition, velocity);
    }
}