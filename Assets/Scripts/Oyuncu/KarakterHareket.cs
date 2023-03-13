using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{
    private Vector3 yon;
    private Vector3 isinCikisNoktasi;
    private float yatay;

    public float hareketHizi;
    public float hareketYumusakligi;
    public float donmeHizi;
    public float kureBuyuklugu;
    public float ziplamaGucu;
    public bool donebilirmi;
    public bool yuruyebilirmi;
    public bool ziplayabilirmi;

    public KeyCode ziplamaTusu;

    public LayerMask yerKatmani;

    public Collider playerCollider;
    public static Rigidbody rb;
    public static Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
        donebilirmi = true;
        yuruyebilirmi = true;
        ziplayabilirmi = true;
    }

    private void LateUpdate()
    {
        animator.SetBool("Yerdemi", Yerdemi());
        if (donebilirmi)
        {
            Donus();
        }

    }
    private void FixedUpdate()
    {
        isinCikisNoktasi = transform.position + Vector3.up / 2;
        if (yuruyebilirmi)
        {
            Yurumek();
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetFloat("Hiz", 0);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(ziplamaTusu))
        {
            Ziplama();
        }
    }
    public void Ziplama()
    {
        if (Yerdemi()&&ziplayabilirmi)
        {
            rb.AddForce(transform.up * ziplamaGucu, ForceMode.Impulse);
            animator.CrossFade("Jumping Up", .1f);
        }
    }

    private void Yurumek()
    {
        yatay = Mathf.Lerp(yatay, -Input.GetAxis("Horizontal"),Time.deltaTime*6);
        yon = new Vector3(0, 0, yatay);
        animator.SetFloat("Hiz", Vector3.ClampMagnitude(yon, 1).magnitude, hareketYumusakligi, Time.deltaTime * 4);
        rb.velocity = new Vector3(0,rb.velocity.y,yon.z * hareketHizi * Time.deltaTime);
    }
    private void Donus()
    {
        transform.forward = Vector3.Slerp(transform.forward, yon, Time.deltaTime * donmeHizi);
    }
    public bool Yerdemi()
    {
        return Physics.CheckSphere(transform.position, kureBuyuklugu,yerKatmani);
    }
    public void Karaketeriİt(Vector3 yon,float guc)
    {
        rb.AddForce(yon * guc, ForceMode.Impulse);
    }
    public void FizigiDuzenle(bool sonuc)
    {
        playerCollider.enabled = sonuc;
        rb.useGravity = sonuc;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position, kureBuyuklugu);
    }


}

