
using UnityEngine;

public interface IDistanceToAimsComparable
{
    public Transform thisTransform { get; }
    public float distancePlayerToAim { get; }
    public void CalculateDistanceAimToPlayer();
}
