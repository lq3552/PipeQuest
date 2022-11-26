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
            dragDropHelper.SelectObject();
            Vector3 mousePosition = UtilClass.GetMousePositionInWorld(-Camera.main.transform.position.z);
            grid.GetXY(mousePosition, out int x, out int y);
            TileGridObject tileGridObject = grid.GetGridObject(x, y);
            GameObject objectToBeBuilt = dragDropHelper.SelectedObject;

            if (tileGridObject != null &&  objectToBeBuilt!= null)
            {
                if (tileGridObject.IsConstructible)
                {
                    //Transform builtTransform = Instantiate(testTransform, grid.GetWorldPosition(x, y), Quaternion.identity);
                    dragDropHelper.DropObject(grid.GetWorldPosition(x, y));
                    tileGridObject.SetTransform(objectToBeBuilt.transform);
                    objectToBeBuilt = null;
                    tileGridObject.SetLogicValue(true);
                }
            }
        }
    }
}