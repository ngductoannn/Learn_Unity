using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 5;
    private List<GameObject> pool;


    private void Start()
    {
        pool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            CreatNewObject();
        }
    }

    private GameObject CreatNewObject()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        pool.Add(obj);
        return obj;
    }

    public GameObject GetPoolObject()
    {
        foreach(GameObject obj in pool)
        {
            if (!obj.activeSelf)
            {
                return obj;
            }
        }
        return CreatNewObject();
    }
}
