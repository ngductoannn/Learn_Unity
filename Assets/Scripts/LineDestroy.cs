using UnityEngine;

public class LineDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            collider.gameObject.SetActive(false);
        }
    }
}
