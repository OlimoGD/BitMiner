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
    [SerializeField]
    private AudioClip coinHitSound;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.Play(coinHitSound, 0.4f, Random.Range(0.95f, 1.05f));
    }
}
