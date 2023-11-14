using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class BakeUpdateMap : MonoBehaviour
{
    public NavMeshSurface surface;

    public void BuildNavMeshUpdate()
    {
        surface.BuildNavMesh();
    }

}