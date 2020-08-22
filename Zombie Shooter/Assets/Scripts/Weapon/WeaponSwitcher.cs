using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int _currentWeapon = 0;
    int previousWeapon;
    // Start is called before the first frame update
    void Start()
    {
        SetWeaponActive();
        previousWeapon = _currentWeapon;
    }

    void Update()
    {
        ProcessKeyInput();
        ProcessScrollWhell();

        if (previousWeapon != _currentWeapon)
        {
            SetWeaponActive();
        }
    }

    private void ProcessScrollWhell()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(_currentWeapon >= transform.childCount - 1)
            {
                previousWeapon = _currentWeapon;
                _currentWeapon = 0;
            }
            else
            {
                previousWeapon = _currentWeapon;
                _currentWeapon++;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (_currentWeapon <= 0)
            {
                previousWeapon = _currentWeapon;
                _currentWeapon = 1;
            }
            else
            {
                previousWeapon = _currentWeapon;
                _currentWeapon--;
            }
        }
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;
        foreach (Transform weapon in transform)
        {
            if(weaponIndex == _currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            previousWeapon = _currentWeapon;
            _currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            previousWeapon = _currentWeapon;
            _currentWeapon = 1;
        }
    }
}
