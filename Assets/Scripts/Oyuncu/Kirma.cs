using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kirma : MonoBehaviour
{
    private Animator animator;
    private KarakterHareket karakter;
    private float sure;

    public Vector3 kutuBuyuklugu;
    public LayerMask zeminMaskesi;
    public GameObject altimdakiObje;
    private float beklemeSuresi;
    public int hasar;

    private void Start()
    {
        karakter= GetComponent<KarakterHareket>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        sure += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (sure>beklemeSuresi&&karakter.Yerdemi())
            {
                StartCoroutine(aksiyon());
                IEnumerator aksiyon()
                {
                    sure = -100;
                    karakter.yuruyebilirmi = false;
                    animator.CrossFade("Ziplama", .25f);
                    karakter.FizigiDuzenle(false);
                    float animasyonUzunlugu = 2.6f;
                    yield return new WaitForSeconds(animasyonUzunlugu);
                    sure = 0;
                    karakter.yuruyebilirmi = true;
                    karakter.FizigiDuzenle(true);
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightControl))
        {
            karakter.yuruyebilirmi = true;
        }
    }
    public void Kir()
    {
        if (altimdakiObje != null)
        {
            if(altimdakiObje.TryGetComponent(out KirilabilirZemin zemin))
            {
                zemin.HasarAl(hasar);
            }
        }
    }
}
