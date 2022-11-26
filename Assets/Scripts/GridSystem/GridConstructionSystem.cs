using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class GridConstructionSystem : MonoBehaviour
{
    [SerializeField] private GridVisual gridVisual;
    [SerializeField] private DragDropHelper dragDropHelper;
    private Grid<TileGridObject> grid;
    private GameObject objectPicked;
    private int[,] objectSpatialSpan;
    private Vector3 anchorFloatError;

    private void Awake()
    {
        grid = new Grid<TileGridObject>(GridConfig.GridWidth, GridConfig.GridHeight, GridConfig.GridCellSize,
            new Vector3(GridConfig.GridCellSize, GridConfig.GridCellSize) * (-5.5f),
            (Grid<TileGridObject> g, int x, int y) => new TileGridObject(g, x, y));
        gridVisual.SetGrid(grid);
        anchorFloatError = new Vector3(GridConfig.GridCellSize, GridConfig.GridCellSize) * 0.1f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (dragDropHelper.SelectedObject == null)
            {
                dragDropHelper.SelectObject();
                AcquireObjectPickedMetaData();
                if (objectPicked != null)
                {
                    // in case object is picked up from a tile
                    grid.GetXY(objectPicked.transform.position + anchorFloatError, out int x, out int y);
                    TileGridObject tileGridObject = grid.GetGridObject(x, y);
                    RecoverTileConstructibility(tileGridObject);
                }
            }
            else
            {
                AcquireObjectPickedMetaData();
                if (objectPicked != null)
                {
                    Vector3 mousePosition = UtilClass.GetMousePositionInWorld(-Camera.main.transform.position.z);
                    grid.GetXY(mousePosition, out int x, out int y);
                    TileGridObject tileGridObject = grid.GetGridObject(x, y);
                    ConstructOnTile(tileGridObject);
                }
            }
        }
    }

    private void AcquireObjectPickedMetaData()
    {
        objectPicked = dragDropHelper.SelectedObject;
        objectSpatialSpan = objectPicked?.GetComponent<ReferToScriptable>().GetReference().GetSpatialSpan();
    }

    private void ConstructOnTile(TileGridObject tileGridObject)
    {
        if (tileGridObject != null)
        {
            bool isConstructible = true;
            for (int i = 0; i < objectSpatialSpan.GetLength(0); i++)
            {
                TileGridObject neighborTileGridObject =
                    grid.GetGridObject(tileGridObject.x + objectSpatialSpan[i, 0], tileGridObject.y + objectSpatialSpan[i, 1]);
                if (neighborTileGridObject == null ||
                    (neighborTileGridObject != null && !neighborTileGridObject.IsConstructible))
                {
                    isConstructible = false;
                    break;
                }
            }

            // place object onto the tile
            if (isConstructible)
            {
                dragDropHelper.DropObject(grid.GetWorldPosition(tileGridObject.x, tileGridObject.y));
                for (int i = 0; i < objectSpatialSpan.GetLength(0); i++)
                {
                    grid.GetGridObject(tileGridObject.x + objectSpatialSpan[i, 0],
                        tileGridObject.y + objectSpatialSpan[i, 1]).SetTransform(objectPicked.transform);
                }
                objectPicked = null;
            }
        }
        else
        {
            dragDropHelper.DropObject();
        }
    }

    private void RecoverTileConstructibility(TileGridObject tileGridObject)
    {
        if (tileGridObject == null)
            return;

        for (int i = 0; i < objectSpatialSpan.GetLength(0); i++)
        {
            grid.GetGridObject(tileGridObject.x + objectSpatialSpan[i, 0],
                tileGridObject.y + objectSpatialSpan[i, 1])?.ClearTransForm();
        }
    }
}