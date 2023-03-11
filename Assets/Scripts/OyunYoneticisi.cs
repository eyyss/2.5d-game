using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunYoneticisi : MonoBehaviour
{
    public static OyunYoneticisi Instance;

    public Transform CMvcam1;
    private void Awake()
    {
        Instance = this;
    }
    public void KameraAcisiniAyarla(Vector3 hedefAci,float donusHizi)
    {
        Vector3 yeniAci = new Vector3(CMvcam1.eulerAngles.x, hedefAci.y, CMvcam1.eulerAngles.z);
        CMvcam1.transform.DORotate(yeniAci,donusHizi);
    }
}
