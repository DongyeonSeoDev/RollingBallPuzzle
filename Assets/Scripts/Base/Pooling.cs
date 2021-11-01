using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling<T> : MonoBehaviour where T : MonoBehaviour
{
    private List<T> poolList = new List<T>();

    [SerializeField] private T poolObject;
    [SerializeField] private Transform parent;

    [SerializeField] private int count = 30;

    protected virtual void Start()
    {
        if (poolObject == null)
        {
            Debug.LogError($"{typeof(T)}�� poolObject�� �����ϴ�.");
        }
        else if (parent == null)
        {
            Debug.LogWarning("parent�� �����ϴ�.");
            parent = transform;
        }

        for (int i = 0; i < count; i++)
        {
            CreatePool();
        }
    }

    protected virtual T CreatePool()
    {
        T pool = Instantiate(poolObject, parent);
        pool.gameObject.SetActive(false);

        poolList.Add(pool);

        return pool;
    }

    protected virtual T GetPool()
    {
        T pool = null;

        for (int i = 0; i < poolList.Count; i++)
        {
            if (!poolList[i].gameObject.activeSelf)
            {
                pool = poolList[i];
            }
        }

        pool ??= CreatePool();
        pool.gameObject.SetActive(true);

        return pool;
    }
}
