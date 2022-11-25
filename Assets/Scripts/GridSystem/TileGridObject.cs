using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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