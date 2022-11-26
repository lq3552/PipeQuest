using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class GridVisual : MonoBehaviour
{
    private Grid<TileGridObject> grid;
    [SerializeField] private GameObject tileMesh;
    [SerializeField] private Material[] tileMaterial = new Material[2];
    private bool isGridUpdated;


    public void SetGrid(Grid<TileGridObject> grid)
    {
        this.grid = grid;
        InitializeTilesVisual();
        this.grid.OnGridModified += Grid_OnGridModified;
    }

    private void InitializeTilesVisual()
    {
        Vector3 offset = new Vector3(0.5f * GridConfig.GridCellSize, 0.5f * GridConfig.GridCellSize, 0.2f);
        for (int x = 0; x < grid.Width; x++)
            for (int y = 0; y < grid.Height; y++)
            {
                grid.GetGridObject(x, y).SetTileMesh(
                    Instantiate(tileMesh, grid.GetWorldPosition(x, y) + offset,
                    Quaternion.identity, transform));
            }
        UpdateTilesVisual();
        grid.OnGridModified += Grid_OnGridModified;
    }

    private void Grid_OnGridModified(object sender, Grid<TileGridObject>.OnGridModifiedCoordinates coordinates)
    {
        isGridUpdated = true;
    }

    private void LateUpdate()
    {
        if (isGridUpdated)
        {
            isGridUpdated = false;
            UpdateTilesVisual();
        }
    }

    private void UpdateTilesVisual()
    {
        for (int x = 0; x < grid.Width; x++)
            for (int y = 0; y < grid.Height; y++)
            {
                TileGridObject tileGridObject = grid.GetGridObject(x, y);
                if (tileGridObject != null)
                {
                    int materialIndex = tileGridObject.IsConstructible ? 0 : 1;
                    tileGridObject.SetTileVisual(tileMaterial[materialIndex]);
                }
            }
    }

}
