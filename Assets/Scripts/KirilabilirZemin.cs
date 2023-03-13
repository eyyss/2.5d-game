using DG.Tweening.Core.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirilabilirZemin : MonoBehaviour
{
    public int can;
    public float geriGelmeSuresi;
    public void HasarAl(int kac)
    {
        can -= kac;
        if (can <= 0)
        {
            GeriGel();
        }
    }
    public void GeriGel()
    {
        StartCoroutine(aksiyon());
        IEnumerator aksiyon()
        {
            Renderer renderer = GetComponent<Renderer>();
            Collider collider = GetComponent<Collider>();
            renderer.enabled = false;
            collider.enabled = false;
            yield return new WaitForSeconds(geriGelmeSuresi);
            renderer.enabled = true;
            collider.enabled = true;
        }
    }
}
