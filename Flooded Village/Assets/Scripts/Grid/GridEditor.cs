using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridEditor : GridHeritage
{
    void Update()
    {
        base.Awake();
        if (!grid.isEditMode) return;

        foreach (GameObject obj in grid.gridList) { DestroyImmediate(obj); }
        grid.gridList.Clear();

        Vector2 newPos = new Vector2 (0, 0);
        for(int i = 0; i < grid.gridX; i++)
        {
            newPos.y = 0;
            newPos.x += 1 + grid.spaceX;
            for (int b = 0; b < grid.gridY; b++)
            {
                newPos.y += 1 + grid.spaceY;
                GameObject newObj = Instantiate(grid.square, newPos, Quaternion.identity);
                newObj.transform.parent = transform;
                grid.gridList.Add(newObj);

                SquareEditor newObjSquareEditor = newObj.GetComponent<SquareEditor>();

                newObjSquareEditor.x = i;
                newObjSquareEditor.y = b;

                newObjSquareEditor.type = SquareType.sand;

                if (i <= grid.waterBorderX - 1
                    || i >= grid.gridX - grid.waterBorderX
                    || b <= grid.waterBorderY - 1
                    || b >= grid.gridY - grid.waterBorderY)
                {
                    newObjSquareEditor.type = SquareType.water;
                }
                newObjSquareEditor.Update();
            }
        }
    }
}
