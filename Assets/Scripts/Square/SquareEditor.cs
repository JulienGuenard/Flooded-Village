using UnityEngine;

[ExecuteInEditMode]
public class SquareEditor : SquareHeritage
{
    public void Update()
    {
        if (square.actualType == square.type) return;

        square.actualType = square.type;
        Debug.Log(square.actualType);
        switch (square.type)
        {
            case SquareType.sand : spriteR.sprite = square.typeSprite[0]; break;
            case SquareType.water : spriteR.sprite = square.typeSprite[1]; break;
            case SquareType.empty: spriteR.sprite = square.typeSprite[2]; break;
        }
    }
}
