using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Square : MonoBehaviour
{
    public SquareType type;
    public List<Sprite> typeSprite;

    SquareType actualType;

    SpriteRenderer spriteR;

    private void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (actualType == type) return;

        actualType = type;

        switch (type)
        {
            case SquareType.sand : spriteR.sprite = typeSprite[0]; break;
            case SquareType.water : spriteR.sprite = typeSprite[1]; break;
        }
    }
}
