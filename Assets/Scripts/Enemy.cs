using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    
    void Update()
    {
        transform.position += new Vector3(speed*Time.deltaTime, 0, 0);
    }
}
