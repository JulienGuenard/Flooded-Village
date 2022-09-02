using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Grid_Editor : MonoBehaviour
{
    public bool isEditMode;
    public GameObject square;
    public int gridX;
    public int gridY;
    public float spaceX;
    public float spaceY;
    public int waterBorderX;
    public int waterBorderY;

    float changeCount = 0;

    public List<GameObject> gridList = new List<GameObject>();

    public static Grid_Editor instance;

    public Square_Editor squareDummy;

    private void Awake()
    {
        if (instance == null) instance = this;

        isEditMode = false;
    }

    void Update()
    {
        if (!isEditMode) return;

        changeCount = gridX + gridY + waterBorderX + waterBorderY + spaceX + spaceY;

        foreach (GameObject obj in gridList) { DestroyImmediate(obj); }
        gridList.Clear();

        Vector2 newPos = new Vector2 (0, 0);
        for(int i = 0; i < gridX; i++)
        {
            newPos.y = 0;
            newPos.x += 1 + spaceX;
            for (int b = 0; b < gridY; b++)
            {
                newPos.y += 1 + spaceY;
                GameObject newObj = Instantiate(square, newPos, Quaternion.identity);
                newObj.transform.parent = transform;
                gridList.Add(newObj);

                Square_Editor newObjSquareEditor = newObj.GetComponent<Square_Editor>();

                newObjSquareEditor.x = i;
                newObjSquareEditor.y = b;

                newObjSquareEditor.type = SquareType.sand;

                if (i <= waterBorderX - 1
                    || i >= gridX - waterBorderX
                    || b <= waterBorderY - 1
                    || b >= gridY - waterBorderY)
                {
                    newObjSquareEditor.type = SquareType.water;
                }
                newObjSquareEditor.Update();
            }
        }
    }

    public Square_Editor GetSquareRight(Square_Editor thisSquare)
    {
        foreach(GameObject obj in gridList)
        {
            Square_Editor objComp = obj.GetComponent<Square_Editor>();
            if (thisSquare.y == objComp.y)
            {
                if (thisSquare.x == objComp.x + 1)
                {
                    return objComp;
                }
            }
                
        }
        return squareDummy;
    }

    public Square_Editor GetSquareLeft(Square_Editor thisSquare)
    {
        foreach (GameObject obj in gridList)
        {
            Square_Editor objComp = obj.GetComponent<Square_Editor>();
            if (thisSquare.y == objComp.y)
            {
                if (thisSquare.x == objComp.x - 1)
                {
                    return objComp;
                }
            }

        }
        return squareDummy;
    }

    public Square_Editor GetSquareTop(Square_Editor thisSquare)
    {
        foreach (GameObject obj in gridList)
        {
            Square_Editor objComp = obj.GetComponent<Square_Editor>();
            if (thisSquare.y == objComp.y + 1)
            {
                if (thisSquare.x == objComp.x)
                {
                    return objComp;
                }
            }

        }
        return squareDummy;
    }

    public Square_Editor GetSquareBottom(Square_Editor thisSquare)
    {
        foreach (GameObject obj in gridList)
        {
            Square_Editor objComp = obj.GetComponent<Square_Editor>();
            if (thisSquare.y == objComp.y - 1)
            {
                if (thisSquare.x == objComp.x)
                {
                    return objComp;
                }
            }

        }
        return squareDummy;
    }
}
