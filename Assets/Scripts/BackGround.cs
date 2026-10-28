using UnityEngine;

public class BackGround : MonoBehaviour
{
    SpriteRenderer sp;
    public Spawn spawn;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Spawn.ChangeColor += ChangeColor;
    }

    private void OnDisable()
    {
        Spawn.ChangeColor -= ChangeColor;
    }

    private void ChangeColor(int i)
    {
        sp.color = Color.gray;
    }


}
