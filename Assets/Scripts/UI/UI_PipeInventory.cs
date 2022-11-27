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
        pipeInventory.OnItemListChanged += PipeInventory_OnItemListChanged;
        RefreshInventoryItems();
    }

    private void PipeInventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach(Transform child in container)
        {
            if (child == pipeSlot)
                continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float pipeSlotCellSize = 100f;
        foreach (KeyValuePair<PipeMetaData, int> pipe in pipeInventory.GetPipeHash())
        {
            RectTransform pipeSlotRectTransform = Instantiate(pipeSlot, container).GetComponent<RectTransform>();
            pipeSlotRectTransform.gameObject.SetActive(true);
            pipeSlotRectTransform.Find("PipeAmount").gameObject.GetComponent<TMP_Text>().text = pipe.Value.ToString();
            pipeSlotRectTransform.Find("PipeIcon").gameObject.GetComponent<Image>().sprite = pipe.Key.pipeComponentSprite;
            pipeSlotRectTransform.Find("PipeMetaData").gameObject.GetComponent<MetadataReference>().SetMetaData(pipe.Key);
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
