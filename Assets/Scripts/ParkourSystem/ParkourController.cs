using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourController : MonoBehaviour
{
    private EnviromentScanner enviromentScanner;
    private void Start()
    {
        enviromentScanner = GetComponent<EnviromentScanner>();

    }
}
