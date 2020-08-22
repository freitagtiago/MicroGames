using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    float health = 30f;
    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player current health is "+health);
        if(health <= 0)
        {
            isAlive = false;
            GetComponent<DeathHandler>().HandleDeath();
        }
    }

    public bool GetIsIsAlive()
    {
        return isAlive;
    }
}
