using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUBox : MonoBehaviour
{
    [SerializeField]
    private Animator gpuBoxOpeningAnimator;
    [SerializeField]
    private HitBox boxOpeningHitBox;

    private void OnEnable()
    {
        boxOpeningHitBox.OnClick += OnHitBoxClicked;
    }

    private void OnDisable()
    {
        boxOpeningHitBox.OnClick -= OnHitBoxClicked;
    }

    public void Open()
    {
        gpuBoxOpeningAnimator.SetTrigger("Open");
    }

    private void OnHitBoxClicked()
    {
        Open();
    }
}
