using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SquareEditor : MonoBehaviour
{
    public SquareType type;
    public List<Sprite> typeSprite;

    SquareType actualType;

    SpriteRenderer spriteR;

    public int x;
    public int y;

    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    public void Update()

    {
        if (actualType == type) return;

        actualType = type;

        switch (type)
        {
            case SquareType.sand : spriteR.sprite = typeSprite[0]; break;
            case SquareType.water : spriteR.sprite = typeSprite[1]; break;
            case SquareType.empty: spriteR.sprite = typeSprite[2]; break;
        }
    }
}
