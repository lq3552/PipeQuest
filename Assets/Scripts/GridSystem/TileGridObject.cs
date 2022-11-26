using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGridObject
{
    private Grid<TileGridObject> grid;
    public int x { get; private set; }
    public int y { get; private set; }
    private Transform transform;
    private bool logicValue;
    private GameObject tileMesh;

    public TileGridObject(Grid<TileGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
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

    public bool IsConstructible
    {
        get
        {
            return transform == null;
        }
    }

    public void SetTransform(Transform transform)
    {
        this.transform = transform;
    }

    public void ClearTransForm()
    {
        transform = null;
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