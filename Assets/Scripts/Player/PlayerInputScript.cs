using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public float vertical,horizontal;
    public bool spacePressed;
    public bool leftShiftPressed;
    public bool leftMouseButtonPresssed;
    public bool rigthMouseButtonPresssed;
    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        spacePressed = Input.GetKeyDown(KeyCode.Space);
        leftShiftPressed = Input.GetKeyDown(KeyCode.LeftShift);
        leftMouseButtonPresssed = Input.GetKeyDown(KeyCode.Mouse1);
        rigthMouseButtonPresssed = Input.GetKeyDown(KeyCode.Mouse0);
    }
}
