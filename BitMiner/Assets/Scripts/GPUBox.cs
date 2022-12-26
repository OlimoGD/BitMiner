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
    private InteractArea openingArea;
    [SerializeField]
    private InteractArea boxArea;
    [SerializeField]
    private GameObject innerBoxGO;

    private void OnEnable()
    {
        openingArea.OnClick += OnOpeningAreaClicked;
        openingMainEvents.OnAnimationFinished += OnOpeningMainAnimationFinished;
        boxArea.OnAreaExited += OnColliderExitedBoxArea;
    }

    private void OnDisable()
    {
        openingArea.OnClick -= OnOpeningAreaClicked;
        openingMainEvents.OnAnimationFinished -= OnOpeningMainAnimationFinished;
        boxArea.OnAreaExited -= OnColliderExitedBoxArea;
    }

    public void Open()
    {
        openingMainAnimator.SetTrigger("Open");
        openingSideAnimator.SetTrigger("Open");
        openingArea.gameObject.SetActive(false);
    }

    private void OnOpeningMainAnimationFinished(string animationName)
    {
        if(animationName == "Open")
        {
            openingMainAnimator.gameObject.GetComponent<SpriteRenderer>()
                .sortingOrder = 11;
        }
    }

    private void OnOpeningAreaClicked()
    {
        Open();
    }

    private void OnColliderExitedBoxArea(Collider2D col)
    {
        if(col.attachedRigidbody.gameObject != innerBoxGO) return;
        //inner box has been slid out
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
