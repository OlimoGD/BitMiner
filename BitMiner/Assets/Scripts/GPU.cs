using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPU : MonoBehaviour
{
    [SerializeField]
    private InteractArea interactArea;
    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private GameObject hitEffectPrefab;

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
            SpawnHitEffect();
            health--;
            if(health <= 0)
            {
                DestroyGPU();
            }
        }
    }

    private void SpawnHitEffect()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int randNumber = Random.Range(0,4);
        float randAngle = 90f * randNumber;
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(0,0,randAngle);
        Instantiate(hitEffectPrefab, mousePos, rot);
    }

    private void DestroyGPU()
    {
        Destroy(this.gameObject);
        GameObject coinGO = Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
        Rigidbody2D coinRigidb = coinGO.GetComponent<Rigidbody2D>();
        coinRigidb.velocity = GetRandomUpwardForce();
    }

    private Vector2 GetRandomUpwardForce()
    {
        float xDir = Random.Range(-1f, 1f);
        Vector2 dir = new Vector2(xDir, 1).normalized;
        float force = 10f;
        return dir * force;
    }
}
