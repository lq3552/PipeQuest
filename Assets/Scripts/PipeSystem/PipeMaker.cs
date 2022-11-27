using System.Collections;
using System.Collections.Generic;
using GameUtils;
using UnityEngine;

public class PipeMaker : MonoBehaviour
{
    private Transform parent;
    Vector3 offset;
    [SerializeField] private DragDropHelper dragDropHelper;

    // I don't like the logic and mouse position come out of nowhere; and crazy interaction between dragDropHelper and this class

    private void Start()
    {
        parent = GameObject.Find("Game Objects").transform;
        offset = new Vector3(GridConfig.GridCellSize, GridConfig.GridCellSize) * (-0.5f);
    }

    public void InstantiatePipeFromPipeMetaData()
    {
        PipeMetaData pipeMetaData = gameObject.GetComponent<MetadataReference>().GetMetaData();
        Instantiate(pipeMetaData.pipeComponentPrefab, UtilClass.GetMousePositionInWorld(-Camera.main.transform.position.z), pipeMetaData.pipeComponentPrefab.transform.rotation, parent);
        dragDropHelper.SelectObject();
        PipeInventory.pipeInventory.RemovePipe(pipeMetaData, 1);
    }
}
