using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeTarayici : MonoBehaviour
{
    private Kirma kirma;
    private void Start()
    {
        kirma = transform.parent.GetComponent<Kirma>();
    }
    private void OnTriggerStay(Collider other)
    {
        kirma.altimdakiObje = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        kirma.altimdakiObje = null;
    }
}
