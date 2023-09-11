using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolShellMortar : MonoBehaviour, IPool<AbsShell>
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private ShellMortar _prefabShellMortar;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<ShellMortar> _poolShellMortar;
    private List<AbsShell> _absShellsList = new List<AbsShell>();

    public List<ShellMortar> getShellMortarList { get; private set; }

    private void Awake()
    {
        _poolShellMortar = new PoolMonoGC<ShellMortar>(_prefabShellMortar, _poolCapasity, transform, _isActiveByDefolt);
        _poolShellMortar.IsAutoExpand = _isAutoExpand;
        getShellMortarList = _poolShellMortar.GetAllElementsList();
        CreateAbsShellList();
    }

    private void CreateAbsShellList()
    {
        foreach (ShellMortar item in getShellMortarList)
        {
            _absShellsList.Add(item);
        }
    }

    public AbsShell GetElement()
    {
        return _poolShellMortar.GetFreeElement();
    }

    public List<AbsShell> GetList()
    {
        return _absShellsList;
    }
}
