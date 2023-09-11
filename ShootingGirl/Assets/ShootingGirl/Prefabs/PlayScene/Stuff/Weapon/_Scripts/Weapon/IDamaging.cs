using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamaging 
{
    public int damage { get; }
    public Transform shootsCharacter { get; }
}
