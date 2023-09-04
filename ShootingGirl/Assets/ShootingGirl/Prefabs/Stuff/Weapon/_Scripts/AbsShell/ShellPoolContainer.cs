using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellPoolContainer : MonoBehaviour
{
    [SerializeField] private PoolShellGun poolSshellGun;

    public PoolShellGun poolShellGun {get { return poolSshellGun; }set { poolSshellGun = value; }}

}
