using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("a")]
   [SerializeField] float speed;
   [SerializeField] Tower tower;
   [SerializeField] Vector3 target;
   [SerializeField] int cur;

    private void Start()
    {
        target = tower.GetPosition(0);
        cur = 0;
    }

    private void Update()
    {
        if(cur < 4)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed*Time.deltaTime);
            if(transform.position == target)
            {
                cur++;
                if(cur <= 3)
                {
                    target = tower.GetPosition(cur);
                }
            }
        }
    }
}
