using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class GridDriver : MonoBehaviour
{
    private Grid grid;

    private void Start()
    {
        grid = new Grid(11,11, 0.85f, new Vector3(-4.675f, -4.675f));
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            grid.SetValue(UtilClass.GetMousePositionInWorld(0.0f), 5);
        }
    }
}
