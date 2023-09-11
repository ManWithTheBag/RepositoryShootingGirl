using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolPlayer : MonoBehaviour
{
    [Min(0)] [SerializeField] private int _poolCapasity;
    [SerializeField] private Player _prefabPlayert;
    [SerializeField] private bool _isActiveByDefolt = false;
    [SerializeField] private bool _isAutoExpand = false;

    private PoolMonoGC<Player> _poolPlayer;

    public List<Player> getPlayerList { get; private set; }
    private void Awake()
    {
        _poolPlayer = new PoolMonoGC<Player>(_prefabPlayert, _poolCapasity, transform, _isActiveByDefolt);
        _poolPlayer.IsAutoExpand = _isAutoExpand;
        getPlayerList = _poolPlayer.GetAllElementsList();
    }
}
