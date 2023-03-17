using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyablePlatform : MonoBehaviour
{
    private float destroyTime;
    public float minTime, maxTime;

    private void Start()
    {
        destroyTime= UnityEngine.Random.Range(minTime,maxTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(gameObject, destroyTime);
        }
    }
}
