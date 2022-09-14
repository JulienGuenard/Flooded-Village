using UnityEngine;
using GridMethodsN;
using System.Collections.Generic;

public class Square : SquareHeritage
{
    public Color colorHovered;
    public Color colorNormal;

    public SquareType type;
    public List<Sprite> typeSprite;

    [HideInInspector] public SquareType actualType;

    public int x;
    public int y;

    bool isHovered = false;
    bool isClicked = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isHovered)
        {
            isClicked = true;
        }

        if (isClicked)
        {
            type = SquareType.empty;
        }

        if (type == SquareType.empty)
        {
            if (GridMethods.GetSquare(square, 0, 1).type == SquareType.water
                || GridMethods.GetSquare(square, 0, -1).type == SquareType.water
                || GridMethods.GetSquare(square, 1, 0).type == SquareType.water
                || GridMethods.GetSquare(square, -1, 0).type == SquareType.water)
            {
                type = SquareType.water;
            }
        }
    }

    private void OnMouseOver()
    {
        if (type != SquareType.sand) return;

        isHovered = true;
        spriteR.color = colorHovered;
    }

    private void OnMouseExit()
    {
        isHovered = false;
        spriteR.color = colorNormal;
    }
}
