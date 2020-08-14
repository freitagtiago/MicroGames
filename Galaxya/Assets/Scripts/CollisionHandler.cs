using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] int sceneToLoad = 1;
    [SerializeField] float levelLoadDelay = 2f;
    [SerializeField] GameObject explosionFx = null;
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
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
