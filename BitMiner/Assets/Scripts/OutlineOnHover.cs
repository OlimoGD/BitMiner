using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineOnHover : MonoBehaviour
{
    [SerializeField]
    private MouseWatcher mouseWatcher;
    [SerializeField]
    private Material spriteOutlineMaterial;
    [SerializeField]
    private Image imageToAlter;

    private Material initialMaterial;

    private void Start()
    {
        initialMaterial = imageToAlter.material;
    }
    
    private void OnEnable()
    {
        mouseWatcher.OnMouseIsOver += OnMouseIsOver;
    }

    private void OnDisable()
    {
        mouseWatcher.OnMouseIsOver -= OnMouseIsOver;
    }

    private void OnMouseIsOver(List<GameObject> gameObjects)
    {
        Debug.Log("asd");
        if(gameObjects.Count <= 0)
        {
            RemoveOutline();
            return;
        }

        if(gameObjects[0] == this.gameObject)
            ApplyOutline();
        else
            RemoveOutline(); 
    }

    private void ApplyOutline()
    {
        imageToAlter.material = spriteOutlineMaterial;
    }

    private void RemoveOutline()
    {
        imageToAlter.material = initialMaterial;
    }
}
