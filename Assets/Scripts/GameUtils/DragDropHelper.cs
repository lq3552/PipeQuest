using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

public class DragDropHelper : MonoBehaviour
{
    private GameObject selectedGameObject;
    private int layerMask;

    private void Start()
    {
        selectedGameObject = null;
        layerMask = LayerMask.GetMask("Pipes");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // use new input system!
        {
            if (!selectedGameObject)
            {
                selectedGameObject = UtilClass.SelectObject(layerMask, "Draggable");
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
                    Camera.main.WorldToScreenPoint(selectedGameObject.transform.position).z);
        }

    }
}
