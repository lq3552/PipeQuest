using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private UI_PipeInventory uiPipeInventory;
    [SerializeField] private InitialInventoryInfo initialInventoryInfo;
    private DragDropHelper dragDropHelper;

    private void Start()
    {
        for (int i = 0; i < initialInventoryInfo.PipeAmountList.Count; i++)
        {
            PipeInventory.pipeInventory.AddPipe(initialInventoryInfo.PipeTypeList[i], initialInventoryInfo.PipeAmountList[i]);
        }
        uiPipeInventory.SetPipeInventory();
        dragDropHelper = gameObject.GetComponent<DragDropHelper>();
    }

    public void RecyclePipe()
    {
        PipeInventory.pipeInventory.AddPipe(dragDropHelper.SelectedObject.GetComponent<MetadataReference>().GetMetaData(), 1);
        Destroy(dragDropHelper.SelectedObject);
        dragDropHelper.DropObject();
    }

}
