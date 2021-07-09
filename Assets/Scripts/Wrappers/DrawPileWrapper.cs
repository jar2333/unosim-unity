using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPileWrapper : MonoBehaviour
{

    DrawPile drawPile;

    void Awake() {
        drawPile = new DrawPile();
    }

    public void FillDraw (Card[] cards) {
        drawPile.Fill(cards);
        Debug.Log($"drawpile is of length {drawPile.Length}");
        drawPile.Shuffle();
    }

    public Card Draw() {
        if (drawPile.IsEmpty()) {
            FieldManager.instance.ResetDiscard();
        }
        return drawPile.Pop(); //if, even after reset, the pile is empty, this will be null
    }

}

