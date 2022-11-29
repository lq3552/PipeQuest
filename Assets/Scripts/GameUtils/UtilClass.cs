using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameUtils
{
    public static class UtilClass
    {
        public const int sortingOrderDefault = 5000;

        // Get Sorting order to set SpriteRenderer sortingOrder, higher position = lower sortingOrder
        public static int GetSortingOrder(Vector3 position, int offset, int baseSortingOrder = sortingOrderDefault)
        {
            return (int)(baseSortingOrder - position.y) + offset;
        }

        public static Vector3 GetMousePositionInWorld(float zetaInScreen)
        {
            Vector3 position = new Vector3(Mouse.current.position.ReadValue().x,
                Mouse.current.position.ReadValue().y,
                zetaInScreen);

            return Camera.main.ScreenToWorldPoint(position);
        }

        public static RaycastHit CastRay(int layerMask = Physics.DefaultRaycastLayers)
        {
            Vector3 worldMousePositionFar = GetMousePositionInWorld(Camera.main.farClipPlane);
            Vector3 worldMousePositionNear = GetMousePositionInWorld(Camera.main.nearClipPlane);
            RaycastHit hit;
            Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out hit, Mathf.Infinity, layerMask);

            return hit;
        }

        public static GameObject SelectObject(int layerMask, string tag)
        {
            RaycastHit hit = UtilClass.CastRay(layerMask);

            if (!hit.collider)
                return null;

            if (hit.collider.transform.parent != null)
            {
                if (hit.collider.transform.parent.gameObject.CompareTag(tag))
                    return hit.collider.transform.parent.gameObject;
                else if (hit.collider.gameObject.CompareTag(tag))
                    return hit.collider.gameObject;
                else
                    return null;
            }
            else
            {
                if (hit.collider.gameObject.CompareTag(tag))
                    return hit.collider.gameObject;
                else
                    return null;
            }
        }

        // Create Text in the World
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 6, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = sortingOrderDefault)
        {
            if (color == null) color = Color.white;
            return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
        }

        // Create Text in the World
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
        {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }
    }
}
