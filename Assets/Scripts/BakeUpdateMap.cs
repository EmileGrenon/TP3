using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class BakeUpdateMap : MonoBehaviour
{
    // Source: https://youtu.be/mV-Uh_FEBn4?si=qv3CJIwviARI8mm8

    public NavMeshSurface surface;

    public void BuildNavMeshUpdate()
    {
        surface.BuildNavMesh();
    }

}