using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ScoreCounter.Instance.OnScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        ScoreCounter.Instance.OnScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int newScore, int oldScore)
    {
        textComponent.text = newScore.ToString();
    }
}
