using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class GridDriver : MonoBehaviour
{
    private Grid<bool> logicGrid;
    [SerializeField] private GridVisual gridVisual;


    private void Start()
    {
        logicGrid = new Grid<bool>(11, 11, 0.85f, new Vector3(-4.675f, -4.675f), false);
        gridVisual.AttachLogicGrid(logicGrid);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = UtilClass.GetMousePositionInWorld(0.0f);
            logicGrid.SetValue(mousePosition, !logicGrid.GetValue(mousePosition));
        }
    }
}
