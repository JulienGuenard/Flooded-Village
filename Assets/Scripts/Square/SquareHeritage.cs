using UnityEngine;

[ExecuteInEditMode]
public class SquareHeritage : MonoBehaviour
{
    [HideInInspector] public SpriteRenderer spriteR;
    [HideInInspector] public Square square;
    [HideInInspector] public SquareEditor squareEditor;

    public void Awake()
    {
        spriteR = GetComponent<SpriteRenderer>();
        square = GetComponent<Square>();
        squareEditor = GetComponent<SquareEditor>();
    }
}
