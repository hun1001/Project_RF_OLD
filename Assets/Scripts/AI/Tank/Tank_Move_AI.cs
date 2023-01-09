using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank;

public class Tank_Move_AI : MonoBehaviour
{
    private Transform _target = null;

    private void Awake()
    {
        _target = FindObjectOfType<Tank_Move>().transform;
    }

    private void Update()
    {
        transform.LookAt(_target);
        if (Vector3.Distance(transform.position, _target.position) > 20f)
        {
            transform.Translate(Vector3.forward * 5f * Time.deltaTime);
        }
    }
}
