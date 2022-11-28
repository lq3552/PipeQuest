using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Initializes the game and controls the scence flow
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    static bool isGamePaused;

    public static bool IsGamePaused
    {
        get
        {
            return isGamePaused;
        }
    }

    private void Awake()
    {
        PauseSession();
        gameManager = this;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PauseSession();
    }

    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void StartSession()
    {
        Time.timeScale = 1.0f;
        isGamePaused = false;
        Physics.autoSyncTransforms = false;
    }

    public void PauseSession()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
        Physics.autoSyncTransforms = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
