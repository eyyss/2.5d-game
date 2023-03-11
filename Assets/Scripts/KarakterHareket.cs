using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using System.Security.Policy;
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
    public float isinUzunlugu;
    public bool donebilirmi;

    public KeyCode ziplamaTusu;

    public LayerMask yerKatmani;

    public HareketTipleri hareketTipi;

    public Collider playerCollider;
    public static Rigidbody rb;
    public static Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
        donebilirmi = true;
    }

    private void LateUpdate()
    {
        animator.SetBool("Yerdemi", Yerdemi());
        if (donebilirmi)
        {
            Donus();
        }
        if (Yerdemi())
        {
            Ziplama();
        }

    }
    private void FixedUpdate()
    {
        isinCikisNoktasi = transform.position + Vector3.up / 2;
        if (hareketTipi== HareketTipleri.yurume)
        {
            AnimatorTrueFalse("Tirmaniyor", OyuncuAksiyonlar.Instance.tirmanabilirMi);
            animator.SetFloat("Y", 0);
            Yurumek();
        }
    }


    private void AnimatorTrueFalse(string animationName,bool a)
    {
        animator.SetBool(animationName, a);
        Debug.Log(animationName+" "+a);
    }
    private void Ziplama()
    {
        if (Input.GetKeyDown(ziplamaTusu))
        {
            rb.AddForce(transform.up * ziplamaGucu, ForceMode.Impulse);
            animator.CrossFade("Jump Forward", .1f);
        }
    }

    private void Yurumek()
    {
        yatay = -Input.GetAxisRaw("Horizontal");
        yon = new Vector3(0, 0, yatay);
        if (Physics.Raycast(isinCikisNoktasi, yon, out RaycastHit hit, isinUzunlugu))
        {
            if (hit.collider != null)
            {
                animator.SetFloat("Hiz", 0);
                return;
            }
        }
        animator.SetFloat("Hiz", Vector3.ClampMagnitude(yon, 1).magnitude, hareketYumusakligi, Time.deltaTime * 4);
    }
    private void Donus()
    {
        transform.forward = Vector3.Slerp(transform.forward, yon, Time.deltaTime * donmeHizi);
    }
    private bool Yerdemi()
    {
        return Physics.CheckSphere(transform.position, kureBuyuklugu,yerKatmani);
    }
    public void YercekiminiDuzenle(bool sonuc)
    {
        rb.velocity = Vector3.zero;
        rb.useGravity = sonuc;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; 
        Gizmos.DrawWireSphere(transform.position, kureBuyuklugu);
        Debug.DrawRay(isinCikisNoktasi, transform.forward * isinUzunlugu);
    }


}

public enum HareketTipleri
{
    yurume,
    tirmanma
}
