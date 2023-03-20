using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private ScoreCounter scoreCounter;
    [SerializeField]
    private TextMeshProUGUI textComponent;

    private void OnEnable()
    {
        //can't use ScoreCounter.Instance here, because Awake is not garanteed to
        //run before every object's OnEnable
        scoreCounter.OnScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        scoreCounter.OnScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(ulong newScore, ulong oldScore)
    {
        textComponent.text = newScore.ToString().PadLeft(7, '0');
    }
}
