using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    float health = 3f;
    public void TakeDamage(float damage)
    {
        health = health - damage;
        if(health <= 0)
        {
            Debug.Log("Died");
            Destroy(gameObject);
        }
    }
}
