using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolShellGun : MonoBehaviour, IPool<AbsShell>
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private ShellGun _prefabShellGun;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<ShellGun> _poolShellGun;
    private List<AbsShell> _absShellsList = new List<AbsShell>();

    public List<ShellGun> getShellGunList { get; private set; }

    private void Awake()
    {
        _poolShellGun = new PoolMonoGC<ShellGun>(_prefabShellGun, _poolCapasity, transform, _isActiveByDefolt);
        _poolShellGun.IsAutoExpand = _isAutoExpand;
        getShellGunList = _poolShellGun.GetAllElementsList();
        CreateAbsShellList();
    }

    private void CreateAbsShellList()
    {
        foreach (ShellGun item in getShellGunList)
        {
            _absShellsList.Add(item);
        }
    }

    public AbsShell GetElement()
    {
        return _poolShellGun.GetFreeElement();
    }

    public List<AbsShell> GetList()
    {
        return _absShellsList;
    }
}
