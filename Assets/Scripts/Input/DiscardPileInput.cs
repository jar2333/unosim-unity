using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPileInput : MonoBehaviour
{

    public DiscardPileWrapper pileWrapper;

    void OnMouseDown() {
        Card[] cards = pileWrapper.GetDiscardPile.Cards.ToArray();
        //show the stats
        Debug.Log("stats");
        foreach(Card c in cards) {
            Debug.Log(c.ToString());
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Collision!");
        GameObject collisionObject = collision.gameObject;
        if (true) { //collisionObject.tag == "Card" 
            Card c = collisionObject.GetComponent<CardWrapper>().GetCard;
            if (gameObject.GetComponent<DiscardPileWrapper>().PlayCard(c)) {  //(force for debug purposes) if play was succesfull, destroy. Otherwise, reset.
                Destroy(collisionObject);
                collisionObject.transform.parent.gameObject.GetComponent<HandWrapper>().RemoveCard(c);
            }
            else {
                Debug.Log("not playable");
                collisionObject.GetComponent<CardInput>().ResetPosition();
            }
        }
    }
}
