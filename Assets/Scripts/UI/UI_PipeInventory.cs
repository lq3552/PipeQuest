using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_PipeInventory : MonoBehaviour
{
    private PipeInventory pipeInventory;
    private int uiPipeInventoryWidth;
    private Transform container;
    private Transform pipeSlot;

    private void Awake()
    {
        uiPipeInventoryWidth = 1;
        container = transform.Find("Container");
        pipeSlot = container.Find("PipeSlot");
    }

    public void SetPipeInventory(PipeInventory pipeInventory)
    {
        this.pipeInventory = pipeInventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        int x = 0;
        int y = 0;
        float pipeSlotCellSize = 100f;
        foreach (Pipe pipe in pipeInventory.GetPipeList())
        {
            RectTransform pipeSlotRectTransform = Instantiate(pipeSlot, container).GetComponent<RectTransform>();
            pipeSlotRectTransform.gameObject.SetActive(true);
            pipeSlotRectTransform.Find("PipeAmount").gameObject.GetComponent<TMP_Text>().text = pipe.Amount.ToString();
            pipeSlotRectTransform.Find("PipeIcon").gameObject.GetComponent<Image>().sprite = pipe.PipeMetaData.pipeComponentSprite;
            pipeSlotRectTransform.anchoredPosition = new Vector2(x * pipeSlotCellSize, y * pipeSlotCellSize);
            x++;
            if(x == uiPipeInventoryWidth)
            {
                x = 0;
                y--;
            }
        }
    }
}
