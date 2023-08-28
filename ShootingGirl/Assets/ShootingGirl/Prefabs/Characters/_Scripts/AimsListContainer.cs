using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimsListContainer : MonoBehaviour
{
    [SerializeField] private PoolEnemyWithGun _poolEnemyWithGun;
    [SerializeField] private PoolEnemyWithRocket _poolEnemyWithRocket;

    private DistanceToAimComparer _distanceToAimComparer = new();
    private List<IDistanceToAimsComparable> _aimList = new();

    private void Start()
    {
        CreateCommonAimList();
    }

    public List<IDistanceToAimsComparable> GetSortedAimList()
    {
        
        foreach (IDistanceToAimsComparable item in _aimList)
        {
            item.CalculateDistanceAimToPlayer();
        }

        _aimList.Sort(_distanceToAimComparer);

        return _aimList;
    }

    private void CreateCommonAimList()
    {
        _aimList.AddRange(_poolEnemyWithGun.GetEnemyWithGunList);
        _aimList.AddRange(_poolEnemyWithRocket.GetEnemyWithRocketList);
    }

}
