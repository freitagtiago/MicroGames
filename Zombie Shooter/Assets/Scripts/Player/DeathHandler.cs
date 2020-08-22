using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas _gameOver;

    private void Awake()
    {
        _gameOver.enabled = false;
    }

    public void HandleDeath()
    {
        _gameOver.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
