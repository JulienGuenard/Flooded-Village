using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridMethodsN
{
    public class GridMethods : GridHeritage
    {
        static public int aaa;
        static public SquareEditor GetSquare(SquareEditor thisSquare, int x, int y)
        {
            foreach (GameObject obj in grid.gridList)
            {
                SquareEditor objComp = obj.GetComponent<SquareEditor>();
                if (thisSquare.y == objComp.y + y)
                {
                    if (thisSquare.x == objComp.x + x)
                    {
                        return objComp;
                    }
                }

            }
            return grid.squareDummy;
        }
    }
}
