using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Variables
    public GameObject targets;
    public GameObject titleScreen;
    public GameObject gameScreen;
    public GameObject gameOverScreen;
    public GameObject endScreen;

    public GameObject tiltsUI;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
    }

    public void StartGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
        gameScreen.SetActive(true);
        targets.SetActive(true);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        gameScreen.SetActive(false);
        isGameActive = false;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
    }
}
