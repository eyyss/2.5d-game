using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public bool canPick = true;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Stone"))
        {
            canPick = false;
        }
        if (collision.collider.CompareTag("Socket"))
        {
            transform.eulerAngles = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            transform.position = collision.transform.position;
        }
    }
}
