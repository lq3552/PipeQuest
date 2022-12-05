using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    private string saveFolder;

    [SerializeField] private int currentLevel;
    public const int MaxLevel = 8;
    LevelInfo levelInfo;

    private class LevelInfo
    {
        public int toBeContinuedLevel;
        public int unlockedLevel;
    }

    private void Awake()
    {
        if (levelManager != null)
        {
            Destroy(gameObject);
            return;
        }
        levelManager = this;

        saveFolder = Application.dataPath + "/Saves";
        if (!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
        }

        LoadLevelInfo();
        UnlockNewLevel();
    }

    private void UnlockNewLevel()
    {
        if (currentLevel > 0)
        {
            levelInfo.toBeContinuedLevel = currentLevel;
            if (levelInfo.unlockedLevel < currentLevel)
            {
                levelInfo.unlockedLevel = currentLevel;
            }
        }
    }

    private void LoadLevelInfo()
    {
        if (File.Exists(saveFolder + "/save.txt"))
        {
            string saveString = File.ReadAllText(saveFolder + "/save.txt");
            levelInfo = JsonUtility.FromJson<LevelInfo>(saveString);
        }
        else
        {
            levelInfo = new LevelInfo{ toBeContinuedLevel = 1, unlockedLevel = 1 };
        }
    }

    public void SaveLevelInfo()
    {
        string saveString = JsonUtility.ToJson(levelInfo);
        File.WriteAllText(saveFolder + "/save.txt", saveString);
    }

    public void ClearLevelInfo()
    {
        currentLevel = 1;
        levelInfo.toBeContinuedLevel = 1;
        levelInfo.unlockedLevel = 1;
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
            return levelInfo.toBeContinuedLevel;
        }
    }

    public int UnlockedLevel
    {
        get
        {
            return levelInfo.unlockedLevel;
        }
    }
}
