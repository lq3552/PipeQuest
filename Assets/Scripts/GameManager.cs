using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Initializes the game and controls the scence flow
/// </summary>
public class GameManager : MonoBehaviour
{
    static bool isGamePaused;

    private void Awake()
    {
        PauseSession();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PauseSession();
    }

    public void StartSession()
    {
        Time.timeScale = 1.0f;
        isGamePaused = false;
    }

    public void PauseSession()
    {
        Time.timeScale = 0f;
        isGamePaused = true;
    }
}
