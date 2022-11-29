using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class GridVisual : MonoBehaviour
{
    private Grid<TileGridObject> grid;
    private bool isGridUpdated;
    Mesh gridMesh;
    Vector2 uvBeginConstructible;
    Vector2 uvBeginInconstructible;
    Vector2 uvBegin;
    const float uvExtent = 0.32f;


    public void SetGrid(Grid<TileGridObject> grid)
    {
        this.grid = grid;
        gridMesh = new Mesh();
        uvBeginConstructible = new Vector2(0.67f, 0.34f);
        uvBeginInconstructible = new Vector2(0.34f, 0.0f);
        gameObject.GetComponent<MeshFilter>().mesh = gridMesh;
        InitializeTileVisual();
        this.grid.OnGridModified += Grid_OnGridModified;
    }

    private void CreateTileMesh()
    {
        Vector3[] vertices = new Vector3[4 * (grid.Width * grid.Height)];
        int[] triangles = new int[6 * (grid.Width * grid.Height)];
        Vector3 offset = grid.OriginPosition + new Vector3(0, 0, 0.1f);


        for (int x = 0; x < grid.Width; x++)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                int index = x * grid.Height + y;
                vertices[index * 4 + 0] = new Vector3(x * grid.CellSize, y * grid.CellSize) + offset;
                vertices[index * 4 + 1] = new Vector3(x * grid.CellSize, (y + 1) * grid.CellSize) + offset;
                vertices[index * 4 + 2] = new Vector3((x + 1) * grid.CellSize, (y + 1) * grid.CellSize) + offset;
                vertices[index * 4 + 3] = new Vector3((x + 1) * grid.CellSize, y * grid.CellSize) + offset;

                triangles[index * 6 + 0] = index * 4 + 0;
                triangles[index * 6 + 1] = index * 4 + 1;
                triangles[index * 6 + 2] = index * 4 + 2;
                triangles[index * 6 + 3] = index * 4 + 0;
                triangles[index * 6 + 4] = index * 4 + 2;
                triangles[index * 6 + 5] = index * 4 + 3;
            }
        }

        gridMesh.vertices = vertices;
        gridMesh.triangles = triangles;
    }

    private void InitializeTileVisual()
    {
        CreateTileMesh();
        UpdateTileVisual();
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
            UpdateTileVisual();
        }
    }

    private void UpdateTileVisual()
    {
        Vector2[] uv = new Vector2[4 * (grid.Width * grid.Height)];

        for (int x = 0; x < grid.Width; x++)
        {
            for (int y = 0; y < grid.Height; y++)
            {
                int index = x * grid.Height + y;
                TileGridObject tileGridObject = grid.GetGridObject(x, y);
                uvBegin = tileGridObject.IsConstructible ? uvBeginConstructible : uvBeginInconstructible;
                uv[index * 4 + 0] = new Vector2(uvBegin.x, uvBegin.y);
                uv[index * 4 + 1] = new Vector2(uvBegin.x, uvBegin.y + uvExtent);
                uv[index * 4 + 2] = new Vector2(uvBegin.x + uvExtent, uvBegin.y + uvExtent);
                uv[index * 4 + 3] = new Vector2(uvBegin.x + uvExtent, uvBegin.y);
            }
        }
        gridMesh.uv = uv;
    }
}
