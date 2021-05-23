using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour, IDestroy
{
    [SerializeField] private MeshDestroy _meshDestroy;
    public void DestroyObject()
    {
        _meshDestroy.DestroyMesh();
    }
}
