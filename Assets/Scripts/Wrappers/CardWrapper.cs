using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardWrapper : MonoBehaviour
{

    public float scaleFactor;
    public SpriteRenderer renderer;

    private Card card;
    public Card GetCard { get {return card;} }

    public void SetCard(Card c)
    {
        card = c;
        renderer.sprite = c.CardSprite;
        //renderer.size = scaleFactor * renderer.size;
    }    
}
