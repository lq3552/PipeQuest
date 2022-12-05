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
        unlockedLevel = 3;
    }

    public void LoadLevelInfo()
    {
        /* load from file */
    }

    public void SaveLevelInfo()
    {
        toBeContinuedLevel = currentLevel;
        if (unlockedLevel < currentLevel)
            unlockedLevel = currentLevel;
        /* save to file */
        Debug.Log("Saving " + currentLevel + "!");
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

    public int UnlockedLevel
    {
        get
        {
            return unlockedLevel;
        }
    }
}
