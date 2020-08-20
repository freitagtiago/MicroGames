using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
     
public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fpCamera;
    [SerializeField] float _shootRange = 100f;
    [SerializeField] float _damage = 1f;
    [SerializeField] ParticleSystem _muzzleFlashPrefab = null;
    [SerializeField] GameObject _hitEffectPrefab = null;
    EnemyHealth target;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();

    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlashPrefab.Play();

    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(_fpCamera.transform.position, _fpCamera.transform.forward, out hit, _shootRange))
        {
            HitEffect(hit);
            target = hit.transform.GetComponent<EnemyHealth>();

            if (target == null) return;

            target.TakeDamage(_damage);
        }
        else
        {
            return;
        }
    }

    private void HitEffect(RaycastHit hit)
    {
        GameObject effect = Instantiate(_hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(effect, 0.5f);
    }
}
