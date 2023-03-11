using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentScanner : MonoBehaviour
{
    public Vector3 forwardRayOffset;
    public float forwardRayLength=.7f;
    public LayerMask groundMask;
    public void ObstacleCheck()
    {
        RaycastHit hitInfo;
        var forwardOrigin= transform.position+ forwardRayOffset;
        bool hitFound=  Physics.Raycast(forwardOrigin,transform.forward, out hitInfo, forwardRayLength,groundMask);
        Debug.DrawRay(forwardOrigin, transform.forward*forwardRayLength,(hitFound)?Color.red:Color.white);
    }
}
