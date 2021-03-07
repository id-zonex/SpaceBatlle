using System;
using System.Collections.Generic;

namespace SpaceBatlle
{

    class BoxColider
    {
        public Transform parent;

        public int minLocalX;
        public int minLocalY;

        public int maxLocalX;
        public int maxLocalY;

        public BoxColider(int minLocalX, int minLocalY, int maxLocalX, int maxLocalY, Transform parent)
        {
            this.parent = parent;

            this.minLocalX = minLocalX;
            this.minLocalY = minLocalY;

            this.maxLocalX = maxLocalX;
            this.maxLocalY = maxLocalY;
        }

        public BoxColider()
        {

        }


        public bool Intersect(Character checkColider)
        {
            if ((checkColider.position.x + checkColider.Sprite.GetLength(0) > parent.position.x && checkColider.position.x - checkColider.Sprite.GetLength(0) < parent.position.x) && (checkColider.position.y + checkColider.Sprite.GetLength(1) > parent.position.y && checkColider.position.y - checkColider.Sprite.GetLength(1) < parent.position.y))
            {
                return true;
            }
            return false;
        }


    }
}
