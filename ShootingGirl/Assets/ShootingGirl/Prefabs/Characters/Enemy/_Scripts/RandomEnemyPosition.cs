using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyPosition : MonoBehaviour
{
    [SerializeField] private Transform _centerSpawnEnemy;
    [SerializeField] private float _radiusOverlapSphere;
    [SerializeField] private float _spawnRadius;
    [SerializeField] LayerMask _includeLayerMask;

    private Collider[] hitColliderArray;

    public Transform centerSpawnEnemy{get { return _centerSpawnEnemy; }private set { _centerSpawnEnemy = value; }}

    public Vector3 GetRandomPosition()
    {
        for (int i = 0; i < 100; i++)
        {
            Vector3 tempRandomPasition = (Random.insideUnitSphere * _spawnRadius) + _centerSpawnEnemy.position;
            tempRandomPasition = new Vector3(tempRandomPasition.x, 0, tempRandomPasition.z);

            if (CheckMapPoint(tempRandomPasition))
            {
                return tempRandomPasition;
            }
        }

        Debug.LogError("LoogError: Haven't find free position for spawn");
        return Vector3.zero;
    }

    private bool CheckMapPoint(Vector3 randomPosition)
    {
        hitColliderArray = Physics.OverlapSphere(randomPosition, _radiusOverlapSphere, _includeLayerMask);
        return (hitColliderArray.Length <= 0) ? true : false;
    }
}
