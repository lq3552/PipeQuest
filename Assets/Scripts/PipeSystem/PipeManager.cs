using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private UI_PipeInventory uiPipeInventory;
    private PipeInventory pipeInventory;
    [SerializeField] private InitialInventoryInfo initialInventoryInfo;

    private void Awake()
    {
        pipeInventory = new PipeInventory();
        for(int i = 0; i < initialInventoryInfo.PipeAmountList.Count; i++)
        {
            Debug.Log(i + " " + initialInventoryInfo.PipeAmountList[i]);
            pipeInventory.AddPipe(new Pipe { PipeMetaData = initialInventoryInfo.PipeTypeList[i], Amount = initialInventoryInfo.PipeAmountList[i]});
        }
        uiPipeInventory.SetPipeInventory(pipeInventory);
    }

}
