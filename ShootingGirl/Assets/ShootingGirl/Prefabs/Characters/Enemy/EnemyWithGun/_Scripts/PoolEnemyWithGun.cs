using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemyWithGun : MonoBehaviour
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private EnemyWithGun _prifabEnemyWithGun;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<EnemyWithGun> _poolEnemyWithGun;

    public List<EnemyWithGun> GetEnemyWithGunList { get; private set; }
    private void Awake()
    {
        _poolEnemyWithGun = new PoolMonoGC<EnemyWithGun>(_prifabEnemyWithGun, _poolCapasity, transform, _isActiveByDefolt);
        _poolEnemyWithGun.IsAutoExpand = _isAutoExpand;
        GetEnemyWithGunList = _poolEnemyWithGun.GetAllElementsList();
    }
}
