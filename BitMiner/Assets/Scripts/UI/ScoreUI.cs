using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private ScoreCounter scoreCounter;
    private TextMeshProUGUI textComponent;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        scoreCounter.OnScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        scoreCounter.OnScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int newScore, int oldScore)
    {
        textComponent.text = newScore.ToString();
    }
}
