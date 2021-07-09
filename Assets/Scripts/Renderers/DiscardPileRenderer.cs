using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPileRenderer : MonoBehaviour
{

    public DiscardPileWrapper discardPileWrapper;
    public SpriteRenderer spriteRenderer;

    public Sprite defaultSprite;

    void Awake() {
        SetDefault();
    }

    public void RenderTop() {
        DiscardPile pile = discardPileWrapper.GetDiscardPile;
        if(!pile.IsEmpty()) {
            spriteRenderer.sprite = discardPileWrapper.GetDiscardPile.Top().CardSprite;
            spriteRenderer.color = Color.white;
        }
        else {
            SetDefault();
        }
    }

    public void SetDefault() {
        spriteRenderer.sprite = defaultSprite;
        spriteRenderer.color = Color.black;
    }
}
