using TMPro;
using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image backGround;
    public TMP_Text scoreText;
    public LineDestroy line;

    private void Start()
    {
        scoreText.text = "SCORE : 0"; 
    }
    private void OnEnable()
    {
        Spawn.ChangeColor += BackGroundChangeColor;
        LineDestroy.IncrementScore += AddAndTextScore;
    }


    private void OnDisable()
    {
        Spawn.ChangeColor -= BackGroundChangeColor;
        LineDestroy.IncrementScore -= AddAndTextScore;
    }

    private void BackGroundChangeColor()
    {
        backGround.color = Color.gray;
    }

    private void AddAndTextScore()
    {
        scoreText.text = "Score : " + line.score;
    }
}
