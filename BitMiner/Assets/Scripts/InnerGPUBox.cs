using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerGPUBox : MonoBehaviour
{
    [SerializeField]
    private InteractArea boxArea;
    [SerializeField]
    private GameObject gpuGO;
    [SerializeField]
    private GPUBox gpuBox;

    private void OnEnable()
    {
        boxArea.OnAreaExited += OnColliderExitedBoxArea;
        gpuBox.OnInnerBoxExited += OnExitedGpuBox;
    }

    private void OnDisable()
    {
        boxArea.OnAreaExited -= OnColliderExitedBoxArea;
        gpuBox.OnInnerBoxExited -= OnExitedGpuBox;
    }

    private void OnExitedGpuBox()
    {
        //enable dragging on gpu
        gpuGO.GetComponent<Draggable>().enabled = true;
    }

    private void OnColliderExitedBoxArea(Collider2D col)
    {        
        if(col?.attachedRigidbody?.gameObject == gpuGO)
        {
            StartCoroutine(DestroyCoroutine());
        }
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
