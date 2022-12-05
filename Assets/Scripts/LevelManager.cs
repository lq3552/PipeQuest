using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    [SerializeField] private int currentLevel;
    private int toBeContinuedLevel;
    private int unlockedLevel;
    public const int MaxLevel = 8;

    private void Awake()
    {
        if (levelManager != null)
        {
            Destroy(gameObject);
            return;
        }
        levelManager = this;
        LoadLevelInfo();
        UnlockNewLevel();
    }

    private void UnlockNewLevel()
    {
        if (currentLevel > 0)
        {
            toBeContinuedLevel = currentLevel;
            if (unlockedLevel < currentLevel)
            {
                unlockedLevel = currentLevel;
            }
        }
    }

    private void LoadLevelInfo()
    {
        toBeContinuedLevel = PlayerPrefs.GetInt("toBeContinuedLevel", 1);
        unlockedLevel = PlayerPrefs.GetInt("unlockedLevel", 1);
    }

    public void SaveLevelInfo()
    {
        /* save to file */
        PlayerPrefs.SetInt("unlockedLevel", unlockedLevel);
        PlayerPrefs.SetInt("toBeContinuedLevel", toBeContinuedLevel);
        PlayerPrefs.Save();
    }

    public void ClearLevelInfo()
    {
        currentLevel = 1;
        toBeContinuedLevel = 1;
        unlockedLevel = 1;
    }

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
    }

    public int ToBeContinuedLevel
    {
        get
        {
            return toBeContinuedLevel;
        }
    }

    public int UnlockedLevel
    {
        get
        {
            return unlockedLevel;
        }
    }
}
