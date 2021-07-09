using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPileWrapper : MonoBehaviour
{
    public DiscardPileRenderer pileRenderer;
    
    private DiscardPile pile;
    private Connectivity fieldConnectivity;
    public Connectivity SetFieldConnectivity {set {fieldConnectivity = value;}}

    void Awake() {
        pile = new DiscardPile();
        pileRenderer.RenderTop();
    }
    
    public DiscardPile GetDiscardPile { get {return pile; }}

    public bool PlayCard(Card c) {  //returns bool indicating if play was succesful 
        //Connectivity connectivity = gameObject.transform.parent.gameObject.GetComponent<Connectivity>();  //replac e   with reference
        if (!pile.IsEmpty())  {
            Card top = pile.Top();
            if (fieldConnectivity.Connects(c, top)) {
                pile.Push(c);
                pileRenderer.RenderTop();
                return true;
            }
        }
        return false;  
    }

    public bool ForcePlayCard(Card c) { //debug method
        Debug.Log("card pushed to discard");
        pile.Push(c);
        pileRenderer.RenderTop();
        return true;
    }

    public Card[] Reset() {
        Card[] cards = pile.Reset();
        pileRenderer.RenderTop();
        return cards;
    }

}
