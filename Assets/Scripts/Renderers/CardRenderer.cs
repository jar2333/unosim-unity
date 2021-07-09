using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRenderer : MonoBehaviour
{

    public GameObject prefab;
    public Sprite defaultSprite;

    void Start() {
        RenderCard(new Vector2(0,0), defaultSprite);
    }

    public void RenderCard(Vector2 position, Card card) {
        RenderCard(position, card.CardSprite);
    }

    public void RenderCard(Vector2 position, Sprite cardSprite) {
        GameObject newCard = Instantiate(prefab, position, Quaternion.identity);
        SpriteRenderer newCardRenderer = newCard.GetComponent<SpriteRenderer>();
        newCardRenderer.sprite = cardSprite;
    }

}

