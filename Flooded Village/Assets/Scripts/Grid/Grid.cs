using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Grid : MonoBehaviour
{
    public GameObject square;
    public int gridX;
    public int gridY;
    public float spaceX;
    public float spaceY;

    int squareCount = 0;

    public List<GameObject> gridList = new List<GameObject>();

    void Update()
    {
        if (squareCount == gridX * gridY) return;
        
        squareCount = gridX * gridY;

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
            }
        }
    }
}
