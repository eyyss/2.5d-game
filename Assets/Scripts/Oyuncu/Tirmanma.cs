using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirmanma : MonoBehaviour
{
    private KarakterHareket karakterHareket;

    private bool t;
    private RaycastHit hit;

    public float tirmanmaHizi;
    public Vector3 rayOffset,assagiRayOffset;
    public float isinUzunlugu,asagiRayUzunlugu;
    public LayerMask zemin;
    private void Start()
    {
        karakterHareket = GetComponent<KarakterHareket>();  
    }
    private void Update()
    {
        Aksiyon();
    }
    public void Aksiyon()
    {
        Animator animator = KarakterHareket.animator;
        if (!TirmanabilirMi())
        {
            if (t)
            {
                KarakterHareket.animator.SetBool("Tirmaniyor", false);
                KarakterHareket.animator.SetFloat("Y", 0);
                t = false;
                if (Tirman())
                {
                    StartCoroutine(Action());
                }
                IEnumerator Action()
                {
                    animator.applyRootMotion = true;
                    animator.CrossFade("Climbing", .1f);
                    karakterHareket.FizigiDuzenle(false);
                    karakterHareket.donebilirmi = false;
                    yield return new WaitForSeconds(3.2f);
                    animator.applyRootMotion = false;
                    karakterHareket.FizigiDuzenle(true);
                    karakterHareket.Karaketeriİt(transform.forward, 8);
                    karakterHareket.donebilirmi = true;
                    karakterHareket.yuruyebilirmi = true;
                }
                print("test");
            }
            return;
        }
        t = true; 
        float dikey = Input.GetAxisRaw("Vertical");
        animator.SetFloat ("Y", dikey);
        float targetZ = hit.point.z+.35f ;
        //transform.DOMoveZ(targetZ, .25f);
        if (dikey != 0)
        {
            animator.SetBool("Tirmaniyor", true);
            karakterHareket.FizigiDuzenle(false);
            karakterHareket.yuruyebilirmi= false;
            if (dikey>0)
            {
                transform.Translate(0, Time.deltaTime * tirmanmaHizi * dikey, 0);
            }
            if (dikey<0)
            {
                if (!YereDegiyorMu())
                {
                    transform.Translate(0, Time.deltaTime * tirmanmaHizi * dikey, 0);
                }
            }

        }
        else
        {
            animator.SetBool("Tirmaniyor", false);
        }

    }
    private bool TirmanabilirMi()
    {
        if (Physics.Raycast(transform.position + rayOffset, transform.forward, out hit, isinUzunlugu))
        {
            if (hit.collider.CompareTag("Merdiven"))
            {
                return true;
            }
            return false;
        }
        return false;
    }
    private bool Tirman()
    {
        if (Physics.Raycast(transform.position + rayOffset, transform.forward, out RaycastHit hit, isinUzunlugu))
        {
            if (hit.collider.name== "MerdivenBitis")
            {
                return true;
            }
            
        }
        return false;
    }
    private bool YereDegiyorMu()
    {
        // ray at assa degiyorsa assa yuruyemicek
        if (Physics.Raycast(transform.position+ assagiRayOffset,transform.up*-1,out RaycastHit asagiHit,asagiRayUzunlugu,zemin))
        {
            if (asagiHit.collider!=null)
            {
                print(hit.collider.name);
                karakterHareket.yuruyebilirmi = true;
                karakterHareket.FizigiDuzenle(true);
                return true;
            }
            return false;
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position + rayOffset, transform.forward * isinUzunlugu);
        Debug.DrawRay(transform.position + assagiRayOffset, transform.up * -1 * asagiRayUzunlugu, Color.blue);
    }
}
