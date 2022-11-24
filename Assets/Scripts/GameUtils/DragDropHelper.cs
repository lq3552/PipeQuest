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
                RaycastHit hit = UtilClass.CastRay(layerMask);

                // All clickable objects have parents according to the scene organization
                if (hit.collider.transform.parent != null)
                {

                    if (hit.collider.transform.parent.gameObject.CompareTag("Draggable"))
                    {
                        selectedGameObject = hit.collider.transform.parent.gameObject;
                        Cursor.visible = false;
                    }
                    else if (hit.collider.gameObject.CompareTag("Draggable"))
                    {
                        selectedGameObject = hit.collider.gameObject;
                        Cursor.visible = false;
                    }
                    else
                    {
                        return;
                    }
                }
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
