using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemyWithRocket : MonoBehaviour, IPool<AbsCharacter>
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private EnemyWithRocket _prefabEnemyWithRocket;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<EnemyWithRocket> _poolEnemyWithRocket;

    public List<EnemyWithRocket> getEnemyWithRocketList { get; private set; }
    private List<AbsCharacter> _absCharacterList = new List<AbsCharacter>();

    private void Awake()
    {
        _poolEnemyWithRocket = new PoolMonoGC<EnemyWithRocket>(_prefabEnemyWithRocket, _poolCapasity, transform, _isActiveByDefolt);
        _poolEnemyWithRocket.IsAutoExpand = _isAutoExpand;
        getEnemyWithRocketList = _poolEnemyWithRocket.GetAllElementsList();
        CreateAbsCharacterList();
    }

    private void CreateAbsCharacterList()
    {
        foreach (AbsCharacter item in getEnemyWithRocketList)
        {
            _absCharacterList.Add(item);
        }
    }

    public AbsCharacter GetElement()
    {
        return _poolEnemyWithRocket.GetFreeElement();
    }

    public List<AbsCharacter> GetList()
    {
        return _absCharacterList;
    }
}
