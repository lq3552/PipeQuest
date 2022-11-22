using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropHelper : MonoBehaviour
{
    private GameObject selectedGameObject;

    private void Start()
    {
        selectedGameObject = null;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // use new input system!
        {
            if (!selectedGameObject)
            {
                RaycastHit hit = CastRay();

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
            Vector3 position = new Vector3(Input.mousePosition.x,
                Input.mousePosition.y,
                Camera.main.WorldToScreenPoint(selectedGameObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedGameObject.transform.position = worldPosition;
        }

    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePositionFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePositionNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);

        Vector3 worldMousePositionFar = Camera.main.ScreenToWorldPoint(screenMousePositionFar);
        Vector3 worldMousePositionNear = Camera.main.ScreenToWorldPoint(screenMousePositionNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out hit);

        return hit;
    }
}
