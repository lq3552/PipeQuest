using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public static PipeManager pipeManager;

    [SerializeField] private UI_PipeInventory uiPipeInventory;
    [SerializeField] private InitialInventoryInfo initialInventoryInfo;

    private void Start()
    {
        for (int i = 0; i < initialInventoryInfo.PipeAmountList.Count; i++)
        {
            PipeInventory.pipeInventory.AddPipe(initialInventoryInfo.PipeTypeList[i], initialInventoryInfo.PipeAmountList[i]);
        }
        uiPipeInventory.SetPipeInventory();
        DragDropHelper.dragDropHelper = gameObject.GetComponent<DragDropHelper>();
    }

    public void RecyclePipe()
    {
        PipeInventory.pipeInventory.AddPipe(DragDropHelper.dragDropHelper.SelectedObject.GetComponent<MetadataReference>().GetMetaData(), 1);
        Destroy(DragDropHelper.dragDropHelper.SelectedObject);
        DragDropHelper.dragDropHelper.DropObject();
    }

}
