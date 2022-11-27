using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PipeMetaData", menuName = "ScriptableObjects/PipeMetaData")]
public class PipeMetaData : ScriptableObject
{
    public GameObject pipeComponentPrefab;
    public Sprite pipeComponentSprite;
    public int width;
    public int height;

    public int[,] GetSpatialSpan()
    {
        int[,] spatialSpan = new int[width * height, 2];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int index = x * height + y;
                spatialSpan[index, 0] = x;
                spatialSpan[index, 1] = y;
            }
        }
        return spatialSpan;
    }
}
