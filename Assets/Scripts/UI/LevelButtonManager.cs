using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonManager : MonoBehaviour
{
    LevelManager levelManager;
    GameManager gameManager;
    private int numButtonPerRow;
    private float intervalX;
    private float intervalY;

    private void Awake()
    {
        numButtonPerRow = 4;
        intervalX = 200;
        intervalY = 200;
    }

    private void Start()
    {
        levelManager = LevelManager.levelManager;
        gameManager = GameManager.gameManager;
        InitializeLevelButton();
    }


    private void InitializeLevelButton()
    {
        Transform levelButtonTemplate = transform.Find("Level Button");
        float left = levelButtonTemplate.localPosition.x;
        float top = levelButtonTemplate.localPosition.y;

        Debug.Log("Get Unlocked: " + levelManager.UnlockedLevel);
        int x = 0;
        int y = 0;
        for (int i = 0; i < LevelManager.MaxLevel; i++)
        {
            RectTransform levelButtonRectTransform = Instantiate(levelButtonTemplate, transform).GetComponent<RectTransform>();
            levelButtonRectTransform.Find("Text").gameObject.GetComponent<TMP_Text>().text = (i + 1).ToString();
            levelButtonRectTransform.anchoredPosition = new Vector2(left + x * intervalX, top + y * intervalY);
            levelButtonRectTransform.gameObject.SetActive(true);

            if (i < levelManager.UnlockedLevel)
            {
                Button button = levelButtonRectTransform.GetComponent<Button>();
                button.interactable = true;
                int level = i + 1;
                button.onClick.AddListener(() => {gameManager.LoadSceneByLevel(level);});

                if(level == levelManager.ToBeContinuedLevel)
                {
                    levelButtonRectTransform.GetComponent<Image>().color = Color.green;
                }
            }

            x++;
            if (x == numButtonPerRow)
            {
                x = 0;
                y--;
            }
        }
    }

    private void Listener()
    {
        Debug.Log("clicked!");
    }

}
