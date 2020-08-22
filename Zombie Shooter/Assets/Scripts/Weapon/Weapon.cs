using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
     
public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _fpCamera;

    [SerializeField] float _shootRange = 100f;
    [SerializeField] float _damage = 1f;
    [SerializeField] float _coolDown = 1f;

    [SerializeField] ParticleSystem _muzzleFlashPrefab = null;
    [SerializeField] GameObject _hitEffectPrefab = null;
    [SerializeField] Ammo _ammoSlot;
    [SerializeField] AmmoType ammoType;

    bool canShoot = true;
    EnemyHealth target;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if(canShoot && _ammoSlot.GetAmmoAmount(ammoType) >=1)
        {
            _ammoSlot.ReduceAmmoAmount(ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
            StartCoroutine("CoolDown");
        }
        else
        {
            Debug.Log("CANT SHOOT");
        }
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

    private IEnumerator CoolDown()
    {
        canShoot = false;
        yield return new WaitForSeconds(_coolDown);
        canShoot = true;
    }

    private void HitEffect(RaycastHit hit)
    {
        GameObject effect = Instantiate(_hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(effect, 0.5f);
    }
}
