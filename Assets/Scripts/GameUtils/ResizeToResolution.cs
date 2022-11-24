using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;

/// <summary>
/// THIS IS A BAD SOLUTION WHEN NON-LINEAR PHYSICS (SUCH AS DRAG = K * VELOCITY) IS CONSIDERED! FINA A WAY TO CHANGE RESOLUTION INSTEAD OF SIZES
/// </summary>
public class ResizeToResolution : MonoBehaviour
{
    /// <summary>
    /// A factor to linearly rescale the physics of the world
    /// </summary>
    public static float RescaleFactor
    {
        get;
        private set;
    }

    private Camera mainCamera;

    void Awake()
    {
        // move all game objects based on the position of main camera
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, 0);
        Vector3 screenSize = new Vector3(ScreenUtils.ScreenWidth, ScreenUtils.ScreenHeight, 0) / 10;
        float screenRatio = screenSize.x / screenSize.y;
        float desiredRatio = transform.localScale.x / transform.localScale.y;
        float size;
        float sizeOrigin = transform.localScale.z;

        if (screenRatio > desiredRatio)
        {
            size = screenSize.y;
            transform.localScale = new Vector3(size * desiredRatio, size, size);
        }
        else
        {
            size = screenSize.x;
            transform.localScale = new Vector3(size, size / desiredRatio, size);
        }
        RescaleFactor = size / sizeOrigin;
    }
}
