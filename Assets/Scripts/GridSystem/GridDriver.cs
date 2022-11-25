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

public class TileGridObject
{
    private Grid<TileGridObject> grid;
    private int x;
    private int y;
    private bool logicValue;
    private GameObject tileMesh;

    public TileGridObject(Grid<TileGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        this.logicValue = false;
        tileMesh = null;
    }

    public bool LogicValue
    {
        get
        {
            return logicValue;
        }
    }

    public GameObject TileMesh
    {
        get
        {
            return tileMesh;
        }
    }

    public void SetLogicValue(bool value)
    {
        logicValue = value;
        grid.TriggerGridObjectChanged(x, y);
    }

    public void SetTileMesh(GameObject tileMesh)
    {
        this.tileMesh = tileMesh;
    }

    public void SetTileVisual(Material material)
    {
        tileMesh.GetComponent<MeshRenderer>().material = material;
    }

    public override string ToString()
    {
        return logicValue.ToString();
    }
}