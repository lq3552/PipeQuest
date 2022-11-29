using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGridObject
{
    private Grid<TileGridObject> grid;
    public int x { get; private set; }
    public int y { get; private set; }
    private Transform transform;

    public TileGridObject(Grid<TileGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
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
        grid.TriggerGridObjectChanged(x, y);
    }

    public void ClearTransForm()
    {
        transform = null;
        grid.TriggerGridObjectChanged(x, y);
    }

    public override string ToString()
    {
        return IsConstructible.ToString();
    }
}