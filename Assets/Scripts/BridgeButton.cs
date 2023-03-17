using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeButton : MonoBehaviour
{
    public GameObject targetObject;
    public float targetScale;
    public bool x,y,z;
    public float Time;
    private bool canOpen;

    private void Start()
    {
        canOpen = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (canOpen)
            {
                Open();
            }
        }
    }

    private void Open()
    {
        canOpen = false;
        var collider = GetComponent<BoxCollider>();
        if (x)
        {
            targetObject.transform.DOScaleX(targetScale, Time).OnComplete(() =>
            {
                canOpen =true;
            });
        }
        if (y)
        {
            targetObject.transform.DOScaleY(targetScale, Time).OnComplete(() =>
            {
                canOpen = true;
            });
        }
        if (z)
        {
            targetObject.transform.DOScaleZ(targetScale, Time).OnComplete(() => { canOpen = true; });
        }
    }
}
