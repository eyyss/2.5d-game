using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Security.Policy;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public PlayerScript playerScript;

    [Header("Physics")]
    public float gravityMultipleir = 3f;// gravityi disardan dusurup yukseltebildiğimiz ancak tamamen kapatamadıgımız kısım
    private float _gravity = -9.91f;
    public float velocity;

    [Header("Movement")]
    private CharacterController characterController;
    public Vector3 inputDirection;
    public float moveSpeed;
    public float moveDampTime;
    public float turnSpeed;// donme hizi

    [Header("Jump")]
    public LayerMask groundMask;
    private bool[] checkHits = new bool[4]; // yerde olup olmadıgını 4 tane ısın ile kontrol ediyoruz. 4 ısınında donderdiği deger
    public List<Vector3> rayStartPositions;// yere dogru gonderilen raylerin baslangic pozisyonları
    public int maxJumpCount;
    public int currentJumpCount;
    public float rayLength;
    public float jumpForce;

    [Header("Dash")]
    [Tooltip("Dashin bekleme süresi")]public float dashCoolDown;
    [Tooltip("Kac saniye dash atıcagı")]public float dashTime;
    [Tooltip("Dashin gucu")]public float dashForce;
    private float dashTimer;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        dashTimer = dashCoolDown;
    }
    private void Update()
    {
        ApplyGravity();
        ApplyMovement();
        Dash();
        playerScript.animator.SetBool("IsLanded", IsGrounded());
    }

    private void ApplyGravity()
    {
        if (characterController.isGrounded)
        {
            velocity = -1f;
            currentJumpCount = maxJumpCount;
            Jump(true);
        }
        else
        {
            velocity += _gravity * gravityMultipleir * Time.deltaTime;
            Jump(false);
        }
    }
    public void Jump(bool oneJump) // one jump true ise sadece 1 kere zıplıcak false ise maxJump count kadar zıplayabilicek
    {
        if (!playerScript.playerInputScript.spacePressed) return;// eger space e basmadıysak 
        if (oneJump)
        {
            currentJumpCount--;
            playerScript.animator.SetInteger("JumpType", 1);
            playerScript.animator.SetTrigger("SpacePressed");
            velocity = Mathf.Sqrt(jumpForce * 2 * -_gravity);
            return;
        }
        else if(currentJumpCount>0)
        {
            velocity = -1f;
            currentJumpCount--;
            int type = UnityEngine.Random.Range(2, 4);
            playerScript.animator.SetInteger("JumpType", type);
            playerScript.animator.SetTrigger("SpacePressed");
            velocity = Mathf.Sqrt(jumpForce * 2 * -_gravity);
        }
    }
    public void Dash()
    {
        dashTimer += Time.deltaTime;
        if (!playerScript.playerInputScript.leftShiftPressed) return;// karakter
        if (characterController.velocity.normalized.magnitude < 0.1f) return;// karakter haraket ediyorsa
        if (dashTimer < dashCoolDown) return;
        dashTimer = 0;
        print("dash atıldı");
        Vector3 dashDirection = inputDirection;
        StartCoroutine(dash());
        IEnumerator dash()
        {
            float startTime = Time.time; // dashin basladıgı oyun zamanını alıyoruz
            while (Time.time<startTime+dashTime) // dashin basladıgı oyun zamanı kucukse şuanki oyun zamanı artı toplam dash süresinden while donuyor
            {
                characterController.Move(dashDirection * dashForce * Time.deltaTime);
                yield return null;
            }
        }
    }
    public void SetGravity(float value)
    {
        _gravity = value;
    }
    private void ApplyMovement()
    {
        inputDirection = new Vector3(playerScript.playerInputScript.horizontal,0, playerScript.playerInputScript.vertical);
        Vector3 move = new Vector3(inputDirection.x, 0,inputDirection.z) ;
        Vector3 camMove = Camera.main.transform.TransformDirection(move);
        camMove.y = 0;
        characterController.Move(new Vector3(camMove.x * moveSpeed, velocity,camMove.z * moveSpeed) * Time.deltaTime);
        playerScript.animator.SetFloat("Speed", Vector3.ClampMagnitude(move,1f).magnitude, moveDampTime, Time.deltaTime*7);
        ApplyRotation(camMove);
    }
    private void ApplyRotation(Vector3 camDirection)
    {
        transform.forward = Vector3.Slerp(transform.forward,camDirection, Time.deltaTime * turnSpeed);
    }
    public CharacterController GetCharacterController()
    {
        return characterController;
    }
    public bool IsGrounded()
    {
        for (int i = 0; i < checkHits.Length; i++)
        {
            checkHits[i] = Physics.Raycast(transform.position + rayStartPositions[i], Vector3.down, rayLength, groundMask);
        }
        for (int i = 0; i < checkHits.Length; i++)
        {
            if (checkHits[i]==true)
            {
                return true;
            }
        }
        return false;
    }
    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < rayStartPositions.Count; i++)
        {
            Color color;
            if (checkHits[i] == true) color = Color.green; else color = Color.red;
            Debug.DrawRay(transform.position + rayStartPositions[i], Vector3.down * rayLength, color);
        }
    }
}

