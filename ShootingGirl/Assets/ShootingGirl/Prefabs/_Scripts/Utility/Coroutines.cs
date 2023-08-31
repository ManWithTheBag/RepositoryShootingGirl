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
            if(_go == null)
            {
                GameObject perent = GameObject.Find("UtilitiesContainer");
                _go = Instantiate(new GameObject("[COROUTINE MANAGER]"), perent.transform);
                s_instanceLerpValue = _go.AddComponent<Coroutines>();
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
        s_instanceLerpValue.StopCoroutine(routine);
    }
}
