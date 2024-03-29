using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPUBox : MonoBehaviour
{
    public delegate void InnerBoxExitedDelegate();
    public event InnerBoxExitedDelegate OnInnerBoxExited;

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
    [SerializeField]
    private GameObject outerBoxGO;
    public AudioManager audioManager;
    [SerializeField]
    private AudioClip boxOpenSound;

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
        audioManager.Play(boxOpenSound, 0.7f, Random.Range(0.95f, 1.05f));
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
        if(col.attachedRigidbody?.gameObject != innerBoxGO) return;
        //inner box has been slid out
        OnInnerBoxExited?.Invoke();
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(outerBoxGO);
    }
}
