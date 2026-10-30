using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text waveText;

    private void OnEnable()
    {
        Spawn.OnWaveChanged += UpdateWaveText;
    }

    private void OnDisable()
    {
        Spawn.OnWaveChanged -= UpdateWaveText;
    }
    private void UpdateWaveText(int currentWave)
    {
        waveText.text = "Wave : " + (currentWave+1);
    }
}
