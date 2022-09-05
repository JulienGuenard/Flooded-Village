using UnityEngine;

public class GridHeritage : MonoBehaviour
{
    [HideInInspector] public GridEditor gridEditor;
    [HideInInspector] static public Grid grid;

    virtual public void Awake()
    {
        gridEditor = GetComponent<GridEditor>();
        grid = GetComponent<Grid>();
    }
}
