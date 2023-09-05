using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolShelRocket : MonoBehaviour, IPool<AbsShell>
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private ShellRocket _prefabShellRocket;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<ShellRocket> _poolShellRocket;
    private List<AbsShell> _absShellsList = new List<AbsShell>();

    public List<ShellRocket> getShellRocketList { get; private set; }

    private void Awake()
    {
        _poolShellRocket = new PoolMonoGC<ShellRocket>(_prefabShellRocket, _poolCapasity, transform, _isActiveByDefolt);
        _poolShellRocket.IsAutoExpand = _isAutoExpand;
        getShellRocketList = _poolShellRocket.GetAllElementsList();
        CreateAbsShellList();
    }

    private void CreateAbsShellList()
    {
        foreach (ShellRocket item in getShellRocketList)
        {
            _absShellsList.Add(item);
        }
    }

    public AbsShell GetElement()
    {
        return _poolShellRocket.GetFreeElement();
    }

    public List<AbsShell> GetList()
    {
        return _absShellsList;
    }
}
