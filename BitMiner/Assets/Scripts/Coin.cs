using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private InteractArea interactArea;
    [SerializeField]
    private ulong value;
    [SerializeField]
    private AudioClip coinPickupSound;
    public AudioManager audioManager;

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
        audioManager.Play(coinPickupSound, 0.4f);
        ScoreCounter.Instance.AddScore(value);
        Destroy(this.gameObject);
    }
}
