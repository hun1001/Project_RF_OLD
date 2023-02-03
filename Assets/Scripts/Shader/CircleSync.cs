using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSync : MonoBehaviour
{
    private static int _posID = Shader.PropertyToID("_Position");
    private static int _sizeID = Shader.PropertyToID("_Size");

    [SerializeField]
    private Material _wallMaterial = null;
    private Camera _camera = null;
    [SerializeField]
    private LayerMask _mask;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Vector3 dir = _camera.transform.position - transform.position;
        Ray ray = new Ray(transform.position, dir.normalized);

        if(Physics.Raycast(ray, 3000, _mask))
        {
            _wallMaterial.SetFloat(_sizeID, 1f);
        }
        else
        {
            _wallMaterial.SetFloat(_sizeID, 0f);
        }

        Vector3 view = _camera.WorldToViewportPoint(transform.position);
        _wallMaterial.SetVector(_posID, view);
    }
}
