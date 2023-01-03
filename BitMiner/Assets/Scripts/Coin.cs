using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private InteractArea interactArea;
    [SerializeField]
    private int value;

    private void OnEnable()
    {
        interactArea.OnClick += OnClick;
    }

    private void OnDisable()
    {
        interactArea.OnClick -= OnClick;
    }

    private void OnClick()
    {
        ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>();
        scoreCounter.AddScore(value);
        Destroy(this.gameObject);
    }
}
