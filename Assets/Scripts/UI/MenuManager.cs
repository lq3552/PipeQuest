using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private Transform mainMenuTransform;
    private Transform levelSelectionTransform;

    private void Awake()
    {
        mainMenuTransform = transform.Find("Main Menu");
        levelSelectionTransform = transform.Find("Level Selection Menu");
    }

    public void SwitchToLevelSelection()
    {
        mainMenuTransform.gameObject.SetActive(false);
        levelSelectionTransform.gameObject.SetActive(true);
    }

    public void SwitchToMainMenu()
    {
        mainMenuTransform.gameObject.SetActive(true);
        levelSelectionTransform.gameObject.SetActive(false);
    }
}
