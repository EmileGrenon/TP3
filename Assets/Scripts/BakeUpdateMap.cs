using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class BakeUpdateMap : MonoBehaviour
{
    // Source: https://youtu.be/mV-Uh_FEBn4?si=qv3CJIwviARI8mm8

    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;

    void Update()
    {
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }

}