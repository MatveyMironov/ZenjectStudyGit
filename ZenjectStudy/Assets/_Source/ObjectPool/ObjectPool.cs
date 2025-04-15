using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : IPoolable
{
    private List<T> _objects = new();

    public T GetObject()
    {

    }

    public T ReturnObject()
    {

    }
}
