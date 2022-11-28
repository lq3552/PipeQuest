using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    public static PipeManager pipeManager;

    public PipeInventory PipeInventory { private set; get; }

    private DragDropHelper dragDropHelper;
    [SerializeField] private UI_PipeInventory uiPipeInventory;
    [SerializeField] private InitialInventoryInfo initialInventoryInfo;

    private void Awake()
    {
        if (pipeManager != null)
        {
            Destroy(gameObject);
            return;
        }
        pipeManager = this;

        PipeInventory = new PipeInventory();
    }

    private void Start()
    {
        dragDropHelper = DragDropHelper.dragDropHelper;
        InitializePipeInventory();
    }

    public void InitializePipeInventory()
    {
        for (int i = 0; i < initialInventoryInfo.PipeAmountList.Count; i++)
        {
            PipeInventory.AddPipe(initialInventoryInfo.PipeTypeList[i], initialInventoryInfo.PipeAmountList[i]);
        }
        uiPipeInventory.SetPipeInventory();
    }

    public void RecyclePipe()
    {
        PipeInventory.AddPipe(dragDropHelper.SelectedObject.GetComponent<MetadataReference>().GetMetaData(), 1);
        Destroy(DragDropHelper.dragDropHelper.SelectedObject);
        dragDropHelper.DropObject();
    }

}
