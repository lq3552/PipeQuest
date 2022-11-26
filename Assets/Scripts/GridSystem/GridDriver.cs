using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class GridDriver : MonoBehaviour
{
    [SerializeField] private Transform testTransform;
    [SerializeField] private GridVisual gridVisual;
    [SerializeField] private DragDropHelper dragDropHelper;
    private Grid<TileGridObject> grid;

    private void Awake()
    {
        grid = new Grid<TileGridObject>(GridConfig.GridWidth, GridConfig.GridHeight, GridConfig.GridCellSize,
            new Vector3(GridConfig.GridCellSize, GridConfig.GridCellSize) * (-5.5f),
            (Grid<TileGridObject> g, int x, int y) => new TileGridObject(g, x, y));
        gridVisual.SetGrid(grid);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = UtilClass.GetMousePositionInWorld(-Camera.main.transform.position.z);
            grid.GetXY(mousePosition, out int x, out int y);
            TileGridObject tileGridObject = grid.GetGridObject(x, y);

            if (dragDropHelper.SelectedObject == null)
            {
                dragDropHelper.SelectObject();
                // in case object is picked up from a tile
                if (dragDropHelper.SelectedObject != null)
                {
                    tileGridObject?.ClearTransForm();
                    tileGridObject?.SetLogicValue(false);
                }
            }
            else
            {
                GameObject objectPicked = dragDropHelper.SelectedObject;
                ConstructOnTile(tileGridObject, objectPicked);
            }
        }
    }

    private void ConstructOnTile(TileGridObject tileGridObject, GameObject objectToBeConstructed)
    {
        if (tileGridObject != null && objectToBeConstructed != null)
        {
            // place object onto the tile
            if (tileGridObject.IsConstructible)
            {
                dragDropHelper.DropObject(grid.GetWorldPosition(tileGridObject.x, tileGridObject.y));
                tileGridObject.SetTransform(objectToBeConstructed.transform);
                objectToBeConstructed = null;
                tileGridObject.SetLogicValue(true);
            }
        }
    }
}