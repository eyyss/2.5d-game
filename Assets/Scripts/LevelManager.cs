using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levelStoneTransforms;
    void Start()
    {
        levelStoneTransforms = GameObject.FindGameObjectsWithTag("Stone");
        InvokeRepeating(nameof(LevelComplateControl), 1f, 1f);
    }

    private void LevelComplateControl()
    {
        print("levelin bitip bitmediði kontrol ediliyor");
        foreach (var stone in levelStoneTransforms)
        {
            Vector3 rot = stone.transform.eulerAngles;
            bool a = rot.z > 3;
            bool b = rot.z < -3;
            if (!a&&!b)
            {
                print("Dusmeyen taslar var");
            }else
            {
                print("Tum taslar dustu");
            }

        }
    }
}
