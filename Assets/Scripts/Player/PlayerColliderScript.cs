using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public float pushForce;
    public GameObject hitObject;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider!=null)
        {
            hitObject = hit.collider.gameObject;
            bool pushable = hit.collider.CompareTag("Stone");// stone degilse
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null&&!rb.isKinematic&&!pushable) 
            {
                rb.velocity = hit.moveDirection * pushForce;
            }
        }
    }
}
