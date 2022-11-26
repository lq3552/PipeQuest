using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class DragDropHelper : MonoBehaviour
{
    private GameObject selectedGameObject;
    private int layerMask;
    private Vector3 offset;

    private void Start()
    {
        selectedGameObject = null;
        layerMask = LayerMask.GetMask("Pipes");
        offset = new Vector3(GridConfig.GridCellSize, GridConfig.GridCellSize) * (-0.5f);
    }

    void Update()
    {
        if (!GameManager.IsGamePaused)
            return;

        if (Input.GetMouseButtonDown(0)) // use new input system!
        {
            if (!selectedGameObject)
            {
                selectedGameObject = UtilClass.SelectObject(layerMask, "Draggable");
                if (selectedGameObject != null)
                    Cursor.visible = false;
            }
            else
            {
                // drop the gameObject
                selectedGameObject = null;
                Cursor.visible = true;
            }
        }

        if (selectedGameObject != null)
        {
            selectedGameObject.transform.position =
                UtilClass.GetMousePositionInWorld(
                    Camera.main.WorldToScreenPoint(selectedGameObject.transform.position).z)
                + offset;
        }

    }
}
