using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtils
{
    /// <summary>
    /// provide global parameters for game configuration
    /// </summary>
    public static class GameConfigs
    {
        static bool isInitialized = false;
        static float gameBoundTop;
        static float gameBoundBottom;
        static float gameBoundLeft;
        static float gameBoundRight;

        /// <summary>
        /// properties returning game configurations
        /// </summary>
        public static float GameBoundTop
        {
            get
            {
                CheckInitialized();
                return gameBoundTop;
            }

        }

        public static float GameBoundBottom
        {
            get
            {
                CheckInitialized();
                return gameBoundBottom;
            }

        }

        public static float GameBoundLeft
        {
            get
            {
                CheckInitialized();
                return gameBoundLeft;
            }

        }

        public static float GameBoundRight
        {
            get
            {
                CheckInitialized();
                return gameBoundRight;
            }

        }

        static void CheckInitialized()
        {
            if (!isInitialized)
            {
                isInitialized = true;
                Initialize();
            }
        }

        static void Initialize()
        {
            gameBoundTop = 4.675f;
            gameBoundBottom = -4.675f;
            gameBoundLeft = -4.675f;
            gameBoundRight = 4.675f;
        }
    }
}
