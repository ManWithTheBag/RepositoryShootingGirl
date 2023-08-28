
using UnityEngine;

public interface IDistanceToAimsComparable
{
    public Transform SortTransform { get; }
    public float DistancePlayerToAim { get; }
    public void CalculateDistanceAimToPlayer();
}
