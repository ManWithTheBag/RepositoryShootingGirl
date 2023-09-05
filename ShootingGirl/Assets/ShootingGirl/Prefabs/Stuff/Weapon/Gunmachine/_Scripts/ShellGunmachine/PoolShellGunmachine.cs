using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolShellGunmachine : MonoBehaviour, IPool<AbsShell>
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private ShellGunmachine _prefabShellGunmachine;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<ShellGunmachine> _poolShellGunmachine;
    private List<AbsShell> _absShellsList = new List<AbsShell>();

    public List<ShellGunmachine> getShellGunmachineList { get; private set; }

    private void Awake()
    {
        _poolShellGunmachine = new PoolMonoGC<ShellGunmachine>(_prefabShellGunmachine, _poolCapasity, transform, _isActiveByDefolt);
        _poolShellGunmachine.IsAutoExpand = _isAutoExpand;
        getShellGunmachineList = _poolShellGunmachine.GetAllElementsList();
        CreateAbsShellList();
    }

    private void CreateAbsShellList()
    {
        foreach (ShellGunmachine item in getShellGunmachineList)
        {
            _absShellsList.Add(item);
        }
    }

    public AbsShell GetElement()
    {
        return _poolShellGunmachine.GetFreeElement();
    }

    public List<AbsShell> GetList()
    {
        return _absShellsList;
    }
}
