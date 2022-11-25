using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class Grid<TGridObject>
{
    int width;
    int height;
    float cellSize;
    Vector3 originPosition;
    TGridObject[,] gridArray;

    bool isDebugOn;
    TextMesh[,] debugTextArray;

    public event EventHandler<OnGridModifiedCoordinates> OnGridModified;
    public class OnGridModifiedCoordinates : EventArgs
    {
        public int x;
        public int y;
    };

    public Grid(int width, int height, float cellSize, Vector3 originPosition, bool isDebugOn = false)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;
        gridArray = new TGridObject[width, height];
        this.isDebugOn = isDebugOn;
        debugTextArray = new TextMesh[width, height];

        if (isDebugOn)
        {
            for (int x = 0; x < gridArray.GetLength(0); x++)
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    debugTextArray[x, y] = UtilClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellSize * 0.25f, 0.5f * cellSize), 20, Color.black);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
        }

    }

    public int Width
    {
        get
        {
            return width;
        }
    }

    public int Height
    {
        get
        {
            return height;
        }
    }

    public float CellSize
    {
        get
        {
            return cellSize;
        }
    }

    public Vector3 OriginPosition
    {
        get
        {
            return originPosition;
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellSize + originPosition;
    }

    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize);
    }

    public void SetValue(int x, int y, TGridObject value)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            if (isDebugOn)
                debugTextArray[x, y].text = gridArray[x, y].ToString();
            OnGridModified?.Invoke(this, new OnGridModifiedCoordinates { x = x, y = y });
        }
    }

    public void SetValue(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    public TGridObject GetValue(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        }
        return default(TGridObject);
    }

    public TGridObject GetValue(Vector3 worldPosition)
    {
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }
}
