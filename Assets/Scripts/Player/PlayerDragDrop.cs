using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragDrop : MonoBehaviour
{
    public PlayerScript playerScript;

    public float objectRotateSpeed;
    public float pushForce;
    public GameObject currentObject;
    private RaycastHit hit;
    private void Update()
    {
        RotateObject();
    }
    
    private void RotateObject() // Elimizde taþ varsa onu donderiyor hepsi için geçerli
    {
        if (currentObject != null)
        {
            Vector3 newRot = currentObject.transform.eulerAngles + new Vector3(0, Input.mouseScrollDelta.y * objectRotateSpeed, 0);
            currentObject.transform.eulerAngles = newRot;
        }
    }
 
}
