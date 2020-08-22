using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType type;
    [SerializeField] int quantity = 1;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            other.transform.GetComponent<Ammo>().IncreaseAmmoAmount(quantity, type);
            Destroy(gameObject, 0.5f);
        }
    }
}
