using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : GridHeritage
{
    public bool isEditMode;
    public GameObject square;
    public int gridX;
    public int gridY;
    public float spaceX;
    public float spaceY;
    public int waterBorderX;
    public int waterBorderY;

    public List<GameObject> gridList = new List<GameObject>();

    public SquareEditor squareDummy;

    public static Grid instance;

    private new void Awake()
    {
        if (instance == null) instance = this;
        base.Awake();
    }
}
