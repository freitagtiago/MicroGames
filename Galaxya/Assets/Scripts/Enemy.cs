using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab = null;
    [SerializeField] Transform parent = null;
    Collider boxCollider;

    private void Awake()
    {
        AddNonTriggeredBoxCollider();    
    }

    private void AddNonTriggeredBoxCollider()
    {
        boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;

    }

    private void OnParticleCollision(GameObject other)
    {
        UIHandler ui = GameObject.Find("Canvas").GetComponent<UIHandler>();
        if(ui != null)
        {
            ui.UpdateScore();
        } else
        {
            print("Não achou UI");
        }
        GameObject explosionFx = Instantiate(explosionPrefab, transform.position,Quaternion.identity);
        explosionFx.transform.parent = parent;
        Debug.Log(explosionFx.transform.position);
        Destroy(gameObject, 1f);
    }
}
