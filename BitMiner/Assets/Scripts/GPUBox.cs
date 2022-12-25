using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUBox : MonoBehaviour
{
    [SerializeField]
    private Animator openingMainAnimator;
    [SerializeField]
    private Animator openingSideAnimator;
    [SerializeField]
    private AnimationEvent openingMainEvents;
    [SerializeField]
    private InteractArea openingHitBox;

    private void OnEnable()
    {
        openingHitBox.OnClick += OnHitBoxClicked;
        openingMainEvents.OnAnimationFinished += OnOpeningMainAnimationFinished;
    }

    private void OnDisable()
    {
        openingHitBox.OnClick -= OnHitBoxClicked;
        openingMainEvents.OnAnimationFinished -= OnOpeningMainAnimationFinished;
    }

    public void Open()
    {
        openingMainAnimator.SetTrigger("Open");
        openingSideAnimator.SetTrigger("Open");
        openingHitBox.gameObject.SetActive(false);
    }

    private void OnOpeningMainAnimationFinished(string animationName)
    {
        if(animationName == "Open")
        {
            openingMainAnimator.gameObject.GetComponent<SpriteRenderer>()
                .sortingOrder = 11;
        }
    }

    private void OnHitBoxClicked()
    {
        Open();
    }

    private void OnMouseDown()
    {
        Debug.Log("clickity");
    }
}
