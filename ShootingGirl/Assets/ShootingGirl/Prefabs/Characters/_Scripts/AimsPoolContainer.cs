using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimsPoolContainer : MonoBehaviour
{
    [SerializeField] private PoolEnemyWithGun _poolEnemyWithGun;
    [SerializeField] private PoolEnemyWithRocket _poolEnemyWithRocket;

    private DistanceToAimComparer _distanceToAimComparer = new();
    private List<IDistanceToAimsComparable> _allAimList = new();
    private List<IDistanceToAimsComparable> _activeAimList = new();
    private List<IDistanceToAimsComparable> _sortedActiveAimList = new();

    private void Start()
    {
        CreateCommonAimList();
        GetNearestAimForPlayer();
    }

    public Transform GetNearestAimForPlayer()
    {
        _sortedActiveAimList = GetSortedActiveAimList();

        if(_sortedActiveAimList.Count != 0)
        {
            return _sortedActiveAimList[0].thisTransform;
            //FoundNearestAimOfPlayerEvent?.Invoke(_nearestAimOfPlayer);
        }

        Debug.Log("Error: neares aim for player not found in script: " + this.GetType());
        return null;
    }

    public List<IDistanceToAimsComparable> GetSortedActiveAimList()
    {
        CreateActiveAimList();

        foreach (IDistanceToAimsComparable item in _activeAimList)
        {
            item.CalculateDistanceAimToPlayer();
        }

        _activeAimList.Sort(_distanceToAimComparer);

        return _activeAimList;
    }

    private void CreateActiveAimList()
    {
        _activeAimList.Clear();

        foreach (IDistanceToAimsComparable item in _allAimList)
        {
            if (item.thisTransform.gameObject.activeSelf)
            {
                _activeAimList.Add(item);
            }
        }
    }

    private void CreateCommonAimList()
    {
        _allAimList.AddRange(_poolEnemyWithGun.getEnemyWithGunList);
        _allAimList.AddRange(_poolEnemyWithRocket.getEnemyWithRocketList);
    }

}
