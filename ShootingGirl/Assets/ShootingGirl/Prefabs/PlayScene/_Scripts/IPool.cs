using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPool<T>
{
    public T GetElement();
    public List<T> GetList();
}
