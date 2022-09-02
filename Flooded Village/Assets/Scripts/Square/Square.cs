using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public Color colorHovered;
    public Color colorNormal;

    bool isHovered = false;
    bool isClicked = false;

    SpriteRenderer spriteR;
    Square_Editor squareEditor;
    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        squareEditor = GetComponent<Square_Editor>();
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
            if (Grid_Editor.instance.GetSquareBottom(squareEditor).type == SquareType.water
                || Grid_Editor.instance.GetSquareTop(squareEditor).type == SquareType.water
                || Grid_Editor.instance.GetSquareLeft(squareEditor).type == SquareType.water
                || Grid_Editor.instance.GetSquareRight(squareEditor).type == SquareType.water)
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
