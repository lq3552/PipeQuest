using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class DragDropHelper : MonoBehaviour
{
    public static DragDropHelper dragDropHelper;

    private GameObject selectedGameObject;
    private int layerMask;
    private Vector3 cursorOffset;

    private void Awake()
    {
        selectedGameObject = null;
        layerMask = LayerMask.GetMask("Pipes");
        cursorOffset = new Vector3(GridConfig.GridCellSize, GridConfig.GridCellSize) * (-0.5f);
    }

    public GameObject SelectedObject
    {
        set
        {
            selectedGameObject = value;
        }
        get
        {
            return selectedGameObject;
        }
    }

    public void SelectObject()
    {
        if (!GameManager.IsGamePaused)
            return;

        if (!selectedGameObject)
        {
            selectedGameObject = UtilClass.SelectObject(layerMask, "Draggable");
            if (selectedGameObject != null)
            {
                Cursor.visible = false;
            }
        }
    }

    private void DeselectObject()
    {
        if (selectedGameObject != null)
        {
            selectedGameObject = null;
            Cursor.visible = true;
        }
    }

    public void DropObject()
    {
        DeselectObject();
    }

    public void DropObject(Vector3 position)
    {
        MoveObject(position);
        DeselectObject();
    }

    private void MoveObject(Vector3 position)
    {
        if (selectedGameObject != null)
        {
            selectedGameObject.transform.position = position;
        }
    }

    private void LateUpdate()
    {
        if (selectedGameObject != null)
        {
            MoveObject(UtilClass.GetMousePositionInWorld(
                        Camera.main.WorldToScreenPoint(selectedGameObject.transform.position).z)
                    + cursorOffset);
        }
    }
}
