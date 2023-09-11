using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolEnemyWithMortar : MonoBehaviour, IPool<AbsCharacter>
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private EnemyWithMortar _prefabEnemyWithMortar;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<EnemyWithMortar> _poolEnemyWithMortar;

    public List<EnemyWithMortar> getEnemyWithMortarList { get; private set; }
    private List<AbsCharacter> _absCharacterList = new List<AbsCharacter>();

    private void Awake()
    {
        _poolEnemyWithMortar = new PoolMonoGC<EnemyWithMortar>(_prefabEnemyWithMortar, _poolCapasity, transform, _isActiveByDefolt);
        _poolEnemyWithMortar.IsAutoExpand = _isAutoExpand;
        getEnemyWithMortarList = _poolEnemyWithMortar.GetAllElementsList();
        CreateAbsCharacterList();
    }

    private void CreateAbsCharacterList()
    {
        foreach (AbsCharacter item in getEnemyWithMortarList)
        {
            _absCharacterList.Add(item);
        }
    }

    public AbsCharacter GetElement()
    {
        return _poolEnemyWithMortar.GetFreeElement();
    }

    public List<AbsCharacter> GetList()
    {
        return _absCharacterList;
    }
}
