using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineOnHover : MonoBehaviour
{
    [SerializeField]
    private MouseArea mouseArea;
    [SerializeField]
    private Material spriteOutlineMaterial;
    [SerializeField]
    private Image imageToAlter;

    private Material initialMaterial;
    private bool outlineOn = false;

    private void Start()
    {
        initialMaterial = imageToAlter.material;
    }
    
    private void OnEnable()
    {
        mouseArea.OnMouseHoverEntered += OnMouseHoverEntered;
        mouseArea.OnMouseHoverExited += OnMouseHoverExited;
    }

    private void OnDisable()
    {
        mouseArea.OnMouseHoverEntered -= OnMouseHoverEntered;
        mouseArea.OnMouseHoverExited -= OnMouseHoverExited;
    }

    private void OnMouseHoverEntered(int zOrder)
    {
        bool isTopMostMouseArea = zOrder == 0;
        if(isTopMostMouseArea) ApplyOutline();
    }

    private void OnMouseHoverExited()
    {
        if(outlineOn) RemoveOutline();
    }

    private void ApplyOutline()
    {
        imageToAlter.material = spriteOutlineMaterial;
        outlineOn = true;
    }

    private void RemoveOutline()
    {
        imageToAlter.material = initialMaterial;
        outlineOn = false;
    }
}
