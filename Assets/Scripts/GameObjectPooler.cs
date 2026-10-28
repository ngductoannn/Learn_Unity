using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class GameObjectPooler : MonoBehaviour
{
    [SerializeField] private TimeData data;
    [SerializeField] private List<GameObject> pool;
    [SerializeField] private GameObject prefab;

    private void Start()
    {
        pool = new List<GameObject>();
    }

    public GameObject CreatNewObject()
    {
        GameObject ois = Instantiate(prefab, transform);
        pool.Add(ois);
        ois.SetActive(false);
        return ois;
    }

    public GameObject Pooler()
    {
        foreach(GameObject ois in pool){
            if (!ois.activeSelf)
            {
                return ois;
            }
        }
        return CreatNewObject();
    }

    public float TimeInterval()
    {
        return data.timeInterval;
    }
}
