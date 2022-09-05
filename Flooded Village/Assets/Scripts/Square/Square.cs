using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridMethodsN;

public class Square : MonoBehaviour
{
    public Color colorHovered;
    public Color colorNormal;

    bool isHovered = false;
    bool isClicked = false;

    SpriteRenderer spriteR;
    SquareEditor squareEditor;
    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        squareEditor = GetComponent<SquareEditor>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isHovered)
        {
            isClicked = true;
        }

        if (isClicked)
        {
            squareEditor.type = SquareType.empty;
        }

        if (squareEditor.type == SquareType.empty)
        {
            if (GridMethods.GetSquare(squareEditor, 0, 1).type == SquareType.water
                || GridMethods.GetSquare(squareEditor, 0, -1).type == SquareType.water
                || GridMethods.GetSquare(squareEditor, 1, 0).type == SquareType.water
                || GridMethods.GetSquare(squareEditor, -1, 0).type == SquareType.water)
            {
                squareEditor.type = SquareType.water;
            }
        }
    }

    private void OnMouseOver()
    {
        if (squareEditor.type == SquareType.water) return;

        isHovered = true;
        spriteR.color = colorHovered;
    }

    private void OnMouseExit()
    {
        isHovered = false;
        spriteR.color = colorNormal;
    }
}
