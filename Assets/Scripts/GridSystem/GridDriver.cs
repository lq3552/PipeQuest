using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class GridDriver : MonoBehaviour
{
    private Grid<bool> grid;
    private int layerMask;
    [SerializeField] private GameObject tileMesh;
    [SerializeField] private Material[] tileMaterial = new Material[2];

    private void Start()
    {
        grid = new Grid<bool>(11, 11, 8.5f, new Vector3(-46.75f, -46.75f));
        layerMask = LayerMask.GetMask("Grid");
        CreateVisibleTile();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.GetXY(UtilClass.GetMousePositionInWorld(0.0f), out int x, out int y);
            grid.SetValue(x, y, !grid.GridArray[x, y]);
            int materialIndex = grid.GridArray[x, y] ? 1 : 0;
            GameObject hitGameObject = UtilClass.SelectObject(layerMask, "Tile");
            UpdateVisual(hitGameObject, tileMaterial[materialIndex]);
        }
    }

    private void CreateVisibleTile()
    {
        for (int x = 0; x < grid.GridArray.GetLength(0); x++)
            for (int y = 0; y < grid.GridArray.GetLength(1); y++)
            {
                GameObject tile = Instantiate(tileMesh, grid.GetWorldPosition(x, y)
                    + new Vector3(grid.CellSize, grid.CellSize) * 0.5f,
                    Quaternion.identity, transform);
                UpdateVisual(tile, tileMaterial[0]);
            }
    }

    private void UpdateVisual(GameObject tile, Material material)
    {
        if (tile != null)
            tile.GetComponent<MeshRenderer>().material = material;
    }
}
