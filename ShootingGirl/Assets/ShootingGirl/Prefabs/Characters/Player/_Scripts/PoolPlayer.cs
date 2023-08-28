using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPlayer : MonoBehaviour
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private Player _prifabPlayert;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<Player> _poolPlayer;

    public List<Player> GetPlayerList { get; private set; }
    private void Awake()
    {
        _poolPlayer = new PoolMonoGC<Player>(_prifabPlayert, _poolCapasity, transform, _isActiveByDefolt);
        _poolPlayer.IsAutoExpand = _isAutoExpand;
        GetPlayerList = _poolPlayer.GetAllElementsList();
    }
}
