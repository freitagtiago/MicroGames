using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fpCamera;
    [SerializeField] float _shootRange = 100f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(_fpCamera.transform.position,_fpCamera.transform.forward, out hit, _shootRange);

        Debug.Log(hit.transform.name);
    }
}
