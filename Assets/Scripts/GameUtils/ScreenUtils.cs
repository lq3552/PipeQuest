using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameUtils
{
    /// <summary>
    /// Provides screen utilities
    /// </summary>
    public static class ScreenUtils
    {
        // saved to support resolution changes
        static int screenWidthDisplay;
        static int screenHeightDisplay;

        // cached for efficient boundary and spawning position checking
        static float screenLeft;
        static float screenRight;
        static float screenTop;
        static float screenBottom;
        static float screenWidth;
        static float screenHeight;
        static float screenDepth;

        /// <summary>
        /// Gets the left edge of the screen in world coordinates
        /// </summary>
        /// <value>left edge of the screen</value>
        public static float ScreenLeft
        {
            get
            {
                CheckScreenSizeChanged();
                return screenLeft;
            }
        }

        /// <summary>
        /// Gets the right edge of the screen in world coordinates
        /// </summary>
        /// <value>right edge of the screen</value>
        public static float ScreenRight
        {
            get
            {
                CheckScreenSizeChanged();
                return screenRight;
            }
        }

        /// <summary>
        /// Gets the top edge of the screen in world coordinates
        /// </summary>
        /// <value>top edge of the screen</value>
        public static float ScreenTop
        {
            get
            {
                CheckScreenSizeChanged();
                return screenTop;
            }
        }

        /// <summary>
        /// Gets the bottom edge of the screen in world coordinates
        /// </summary>
        /// <value>bottom edge of the screen</value>
        public static float ScreenBottom
        {
            get
            {
                CheckScreenSizeChanged();
                return screenBottom;
            }
        }

        /// <summary>
        /// Gets the width of the screen in world coordinates
        /// </summary>
        /// <value>bottom edge of the screen</value>
        public static float ScreenWidth
        {
            get
            {
                CheckScreenSizeChanged();
                return screenWidth;
            }
        }

        /// <summary>
        /// Gets the height of the screen in world coordinates
        /// </summary>
        /// <value>bottom edge of the screen</value>
        public static float ScreenHeight
        {
            get
            {
                CheckScreenSizeChanged();
                return screenHeight;
            }
        }

        /// <summary>
        /// Gets the depth of the screen in world coordinates
        /// </summary>
        /// <value>z coordinate of the screen</value>
        public static float ScreenDepth
        {
            get
            {
                CheckScreenSizeChanged();
                return screenDepth;
            }
        }

        /// <summary>
        /// Initializes the screen utilities
        /// </summary>
        public static void Initialize()
        {
            // save to support resolution changes
            screenWidthDisplay = Screen.width;
            screenHeightDisplay = Screen.height;

            // save screen edges in world coordinates
            float screenZ = -Camera.main.transform.position.z;
            Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);
            Vector3 upperRightCornerScreen = new Vector3(
                screenWidthDisplay, screenHeightDisplay, screenZ);
            Vector3 lowerLeftCornerWorld =
                Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);
            Vector3 upperRightCornerWorld =
                Camera.main.ScreenToWorldPoint(upperRightCornerScreen);
            screenLeft = lowerLeftCornerWorld.x;
            screenRight = upperRightCornerWorld.x;
            screenTop = upperRightCornerWorld.y;
            screenBottom = lowerLeftCornerWorld.y;
            screenWidth = screenRight - screenLeft;
            screenHeight = screenTop - screenBottom;
            screenDepth = lowerLeftCornerScreen.z;
        }

        /// <summary>
        /// Checks for screen size change
        /// </summary>
        static void CheckScreenSizeChanged()
        {
            if (screenWidthDisplay != Screen.width ||
                screenHeightDisplay != Screen.height)
            {
                Initialize();
            }
        }
    }
}