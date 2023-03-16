using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public float vertical,horizontal;
    public bool spacePressed;
    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        spacePressed = Input.GetKeyDown(KeyCode.Space);
    }
}
