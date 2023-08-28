using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbsCharacter
{
    public static Transform s_playerTransform;


    public override void Awake()
    {
        base.Awake();
        s_playerTransform = transform;
    }
}
