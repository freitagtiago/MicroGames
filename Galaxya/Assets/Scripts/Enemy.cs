using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int points = 1;
    [SerializeField] int health = 1;
    [SerializeField] bool isDead = false;
    [SerializeField] GameObject explosionPrefab = null;
    [SerializeField] Transform parent = null;
    Collider boxCollider;
    UIHandler ui;


    private void Awake()
    {
        AddNonTriggeredBoxCollider();
        ui = FindObjectOfType<UIHandler>();
    }

    private void AddNonTriggeredBoxCollider()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;

    }

    private void OnParticleCollision(GameObject other)
    {
        if (!isDead)
        {
            ui.UpdateScore(points);
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            isDead = true;
            GameObject explosionFx = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            //explosionFx.transform.parent = parent;
            GetComponent<MeshRenderer>().gameObject.SetActive(false);
            Destroy(explosionFx, 1f);
            Destroy(gameObject, 1f);
        }
    }

    public bool GetIsDead()
    {
        return isDead;
    }

}
