using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent<Transform> GetNewAimForPlayerEvent = new();
    public static UnityEvent<PlayerModelEnum> ChangePlayerModelStateEvent = new();
    public static UnityEvent DiedPlayerModelEvent = new();
    public static UnityEvent<int> UpdatedCurrentScoreEvent = new();
}
