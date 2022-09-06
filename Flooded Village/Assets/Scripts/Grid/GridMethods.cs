using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridMethodsN
{
    public class GridMethods : GridHeritage
    {
        static public int[] aaa;
        static public Square GetSquare(Square thisSquare, int x, int y)
        {
            foreach (GameObject obj in grid.gridList)
            {
                Square objComp = obj.GetComponent<Square>();
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
