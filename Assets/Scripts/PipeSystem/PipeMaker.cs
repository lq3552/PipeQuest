using System.Collections;
using System.Collections.Generic;
using GameUtils;
using UnityEngine;

public class PipeMaker : MonoBehaviour
{
    private PipeManager pipeManager;
    private DragDropHelper dragDropHelper;
    private Transform parent;
    Vector3 offset;

    // I don't like the logic and mouse position come out of nowhere; and crazy interaction between dragDropHelper and this class

    private void Start()
    {
        pipeManager = PipeManager.pipeManager;
        dragDropHelper = DragDropHelper.dragDropHelper;

        parent = GameObject.Find("Game Objects").transform;
        offset = new Vector3(GridConfig.GridCellSize, GridConfig.GridCellSize) * (-0.5f);
    }

    public void InstantiatePipeFromPipeMetaData()
    {
        if (GameManager.IsGamePaused)
        {
            PipeMetaData pipeMetaData = gameObject.GetComponent<MetadataReference>().GetMetaData();
            Instantiate(pipeMetaData.pipeComponentPrefab, UtilClass.GetMousePositionInWorld(-Camera.main.transform.position.z), pipeMetaData.pipeComponentPrefab.transform.rotation, parent);
            dragDropHelper.SelectObject();
            pipeManager.PipeInventory.RemovePipe(pipeMetaData, 1);
        }
    }
}
