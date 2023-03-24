using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundInArea : MonoBehaviour
{
    [SerializeField]
    private MouseArea mouseArea;
    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private AudioClip clickSound;

    private void OnEnable()
    {
        mouseArea.OnMousePrimaryButtonPressed += OnMouseButtonPressedWhileInTheArea;
        mouseArea.OnMouseSecondaryButtonPressed += OnMouseButtonPressedWhileInTheArea;
    }

    private void OnDisable()
    {
        mouseArea.OnMousePrimaryButtonPressed -= OnMouseButtonPressedWhileInTheArea;
        mouseArea.OnMouseSecondaryButtonPressed -= OnMouseButtonPressedWhileInTheArea;
    }

    private void OnMouseButtonPressedWhileInTheArea(int zOrder)
    {
        audioManager.Play(clickSound, 0.4f, Random.Range(0.9f, 1.1f));
    }
}
