using DG.Tweening;
using System;
using System.Collections;
using System.Security.AccessControl;
using UnityEngine;

public class OyuncuAksiyonlar : MonoBehaviour
{
    public static OyuncuAksiyonlar Instance;

    private KarakterHareket karakterHaraket;
    public bool tirmanabilirMi;
    
   
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        karakterHaraket =GetComponent<KarakterHareket>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KameraDondurucu"))
        {
            Vector3 dir = transform.position - other.transform.position;
            Vector3 hedef = new Vector3(0, 90, 0);
            if (dir.z > .1f) hedef = new Vector3(0, 110, 0);  // 20 ekleyip 20 cıkarıyoruz
            if (dir.z < -.1f) hedef = new Vector3(0, 70, 0);
            OyunYoneticisi.Instance.KameraAcisiniAyarla(hedef,1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("KameraDondurucu"))
        {
            tirmanabilirMi = false;
            OyunYoneticisi.Instance.KameraAcisiniAyarla(new Vector3(0, 90, 0), 1f);
        }
    }


}

