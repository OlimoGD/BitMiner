using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU : MonoBehaviour
{
    [SerializeField]
    private InteractArea interactArea;

    [SerializeField]
    private int health = 10;
    public int Health
    {
        get { return health; }
    }

    [SerializeField]
    private bool isDestroyable = false;
    public bool IsDestroyable
    {
        get { return isDestroyable; }
        set { isDestroyable = value; }
    }

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
        if(isDestroyable)
        {
            health--;
            if(health <= 0)
            {
                OnDestroyGPU();
            }
        }
    }

    private void OnDestroyGPU()
    {
        StartCoroutine(DestroyCoroutine());
    }

    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
