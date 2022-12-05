using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/// <summary>
/// Initializes the game and controls the scence flow
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    static bool isGamePaused;

    private LevelManager levelManager;

    public static bool IsGamePaused
    {
        get
        {
            return isGamePaused;
        }
    }

    private void Awake()
    {
        if (gameManager != null)
        {
            Destroy(gameObject);
            return;
        }
        gameManager = this;
        PauseSession();
    }

    private void Start()
    {
        levelManager = LevelManager.levelManager;
        Debug.Log("Set " + LevelManager.levelManager);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PauseSession();
    }

    public void LoadScene(string scene)
    {
        if (scene == "Menu")
            levelManager.SaveLevelInfo();
        SceneManager.LoadScene(scene);
    }

    public void LoadSceneByLevel(int level)
    {
        string scene = "Level" + level;
        LoadScene(scene);
    }

    public void LoadNextScene() => LoadSceneByLevel(levelManager.CurrentLevel + 1);

    public void PauseOrUnpauseSession(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (isGamePaused)
        {
            StartSession();
        }
        else
        {
            PauseSession();
        }
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
        if (SceneManager.GetActiveScene().name != "Menu")
            levelManager.SaveLevelInfo();
        Application.Quit();
    }
}
