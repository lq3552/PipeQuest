using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class GridDriver : MonoBehaviour
{
    [SerializeField] private GridVisual gridVisual;
    private Grid<TileGridObject> grid;

    private void Start()
    {
        grid = new Grid<TileGridObject>(11, 11, GridConfig.GridCellSize,
            new Vector3(GridConfig.GridCellSize, GridConfig.GridCellSize) * (-5.5f),
            (Grid<TileGridObject> g, int x, int y) => new TileGridObject(g, x, y));
        gridVisual.SetGrid(grid);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = UtilClass.GetMousePositionInWorld(0.0f);
            TileGridObject tileGridObject = grid.GetGridObject(mousePosition);
            tileGridObject?.SetLogicValue(!tileGridObject.LogicValue);
        }
    }
}