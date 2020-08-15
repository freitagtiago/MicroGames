using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] int sceneToLoad = 1;
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject explosionFx = null;
    [SerializeField] int health = 10;
    bool isDead = false;
    UIHandler ui;

    private void Awake()
    {
        ui = FindObjectOfType<UIHandler>();
    }

    private void Update()
    {
        ui.UpdateHealth(health);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if(other.transform.tag == "Enemy")
        {
            if (other.GetComponent<Enemy>().GetIsDead()) return;
        }
        TakeDamage();
    }

    private void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            isDead = true;
            StartDeathSequence();
        }
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        explosionFx.SetActive(true);
        Invoke("LoadLevel", levelLoadDelay);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
