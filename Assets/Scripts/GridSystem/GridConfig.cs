using System.Collections;
using System.Collections.Generic;

namespace GameUtils
{
    public static class GridConfig
    {
        static float gridCellSize = 0.85f;
        static int gridWidth = 11;
        static int gridHeight = 11;

        public static float GridCellSize
        {
            get
            {
                return gridCellSize;
            }
        }

        public static int GridWidth
        {
            get
            {
                return gridWidth;
            }
        }

        public static int GridHeight
        {
            get
            {
                return gridHeight;
            }
        }

    }
}