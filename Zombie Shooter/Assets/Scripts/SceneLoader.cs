using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject _gameOver;
    // Start is called before the first frame update

    public void RestartScene()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void GameOverScene()
    {
        _gameOver.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
