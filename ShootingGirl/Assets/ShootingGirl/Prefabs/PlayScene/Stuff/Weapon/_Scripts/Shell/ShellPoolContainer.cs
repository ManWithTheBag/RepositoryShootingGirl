using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPoolContainer : MonoBehaviour
{
    [SerializeField] private PoolShellGun _poolSshellGun;
    [SerializeField] private PoolShellGunmachine _poolShellGunmachine;
    [SerializeField] private PoolShelRocket _poolShelRocket;
    [SerializeField] private PoolShellMortar _poolShellMortar;


    public PoolShellGun poolShellGun {get { return _poolSshellGun; }set { _poolSshellGun = value; }}
    public PoolShellGunmachine poolShellGunmachine { get { return _poolShellGunmachine; } set { _poolShellGunmachine = value; } }
    public PoolShelRocket poolShelRocket { get { return _poolShelRocket; } set { _poolShelRocket = value; } }
    public PoolShellMortar poolShellMortar { get { return _poolShellMortar; } set { poolShellMortar = value; } }


}
