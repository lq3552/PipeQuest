using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridVisual : MonoBehaviour
{
    private Grid<bool> logicGrid;
    private Grid<GameObject> visualGrid;
    [SerializeField] private GameObject tileMesh;
    [SerializeField] private Material[] tileMaterial = new Material[2];
    private bool isLogicGridUpdated;


    public void AttachLogicGrid(Grid<bool> grid)
    {
        logicGrid = grid;
        visualGrid = new Grid<GameObject>(grid.Width, grid.Height, grid.CellSize,
            grid.OriginPosition + new Vector3(grid.CellSize, grid.CellSize, 0.4f) * 0.5f);
        CreateTilesVisual();
        logicGrid.OnGridModified += Grid_OnGridModified;
    }

    private void CreateTilesVisual()
    {
        for (int x = 0; x < visualGrid.Width; x++)
            for (int y = 0; y < visualGrid.Height; y++)
            {
                visualGrid.SetValue(x, y, Instantiate(tileMesh, visualGrid.GetWorldPosition(x, y),
                    Quaternion.identity, transform));
            }
        UpdateTilesVisual();
    }

    private void Grid_OnGridModified(object sender, Grid<bool>.OnGridModifiedCoordinates coordinates)
    {
        isLogicGridUpdated = true;
    }

    private void LateUpdate()
    {
        if(isLogicGridUpdated)
        {
            isLogicGridUpdated = false;
            UpdateTilesVisual();
        }
    }

    private void UpdateSingleTileVisual(GameObject tile, Material material)
    {
        if (tile != null)
            tile.GetComponent<MeshRenderer>().material = material;
    }

    private void UpdateTilesVisual()
    {
        for (int x = 0; x < logicGrid.Width; x++)
            for (int y = 0; y < logicGrid.Height; y++)
            {
                int materialIndex = logicGrid.GetValue(x, y) ? 1 : 0;
                UpdateSingleTileVisual(visualGrid.GetValue(x, y), tileMaterial[materialIndex]);
            }
    }
        
}
