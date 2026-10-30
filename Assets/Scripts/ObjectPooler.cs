using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
   [SerializeField] private GameObject prefab;
    private int poolSize = 5;
    private List<GameObject> pool;

    private void Start()
    {
        pool = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject ois = Instantiate(prefab, transform);
        pool.Add(ois);
        ois.SetActive(false);
        return ois;
    }

    public GameObject GetPooledObject()
    {
        foreach(GameObject ois in pool){
            if (!ois.activeSelf)
            {
                return ois;
            }
        }
        return CreateNewObject();
    }


}
