using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Coroutines : MonoBehaviour
{
    private static Coroutines s_instanceLerpValue;
    private static GameObject _go;

    public static Coroutines instanceLerpValue
    {
        get
        {
            if(s_instanceLerpValue == null)
            {
                _go = Instantiate(new GameObject("[COROUTINE MANAGER]"));
                s_instanceLerpValue = _go.AddComponent<Coroutines>();
                DontDestroyOnLoad(_go);
            }

            return s_instanceLerpValue;
        }

    }

    public Coroutine StartRoutine(IEnumerator enumerator)
    {
        return s_instanceLerpValue.StartCoroutine(enumerator);
    }

    public void StopRoutine(Coroutine routine)
    {
        if(s_instanceLerpValue != null && routine != null)
            s_instanceLerpValue.StopCoroutine(routine);
    }
}
