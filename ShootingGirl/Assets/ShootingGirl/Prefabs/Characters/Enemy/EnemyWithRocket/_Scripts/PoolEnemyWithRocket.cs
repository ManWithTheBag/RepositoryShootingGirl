using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemyWithRocket : MonoBehaviour
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private EnemyWithRocket _prifabEnemyWithRocket;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<EnemyWithRocket> _poolEnemyWithRocket;

    public List<EnemyWithRocket> GetEnemyWithRocketList { get; private set; }
    private void Awake()
    {
        _poolEnemyWithRocket = new PoolMonoGC<EnemyWithRocket>(_prifabEnemyWithRocket, _poolCapasity, transform, _isActiveByDefolt);
        _poolEnemyWithRocket.IsAutoExpand = _isAutoExpand;
        GetEnemyWithRocketList = _poolEnemyWithRocket.GetAllElementsList();
    }
}
