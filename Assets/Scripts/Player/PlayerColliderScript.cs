using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public float pushForce;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider!=null)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb != null&&!rb.isKinematic) 
            {
                rb.velocity = hit.moveDirection * pushForce;
            }
        }
    }
}
