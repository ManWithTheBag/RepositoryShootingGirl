using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemyWithGun : MonoBehaviour, IPool<AbsCharacter>
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private EnemyWithGun _prefabEnemyWithGun;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<EnemyWithGun> _poolEnemyWithGun;
    private List<AbsCharacter> _absCharacterList = new List<AbsCharacter>();

    public List<EnemyWithGun> getEnemyWithGunList { get; private set; }

    private void Awake()
    {
        _poolEnemyWithGun = new PoolMonoGC<EnemyWithGun>(_prefabEnemyWithGun, _poolCapasity, transform, _isActiveByDefolt);
        _poolEnemyWithGun.IsAutoExpand = _isAutoExpand;
        getEnemyWithGunList = _poolEnemyWithGun.GetAllElementsList();
        CreateAbsCharacterList();
    }

    private void CreateAbsCharacterList()
    {
        foreach (AbsCharacter item in getEnemyWithGunList)
        {
            _absCharacterList.Add(item);
        }
    }

    public AbsCharacter GetElement()
    {
        return _poolEnemyWithGun.GetFreeElement();
    }

    public List<AbsCharacter> GetList()
    {
        return _absCharacterList;
    }
}
