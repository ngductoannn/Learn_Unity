using UnityEngine;
using System;

public class LineDestroy : MonoBehaviour
{
    public int score;
    public static event Action IncrementScore;


    private void Start()
    {
        score = 0;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.SetActive(false);
            score++;
            IncrementScore?.Invoke();
        }
    }
}
