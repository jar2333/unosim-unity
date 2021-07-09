using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DiscardPile
{
    private List<Card> cards;
    public List<Card> Cards {get {return cards;}}

    public DiscardPile() {
        cards = new List<Card>();
    }

    public DiscardPile(Card initial) {
        cards = new List<Card>();
        cards.Add(initial);
    }

    public Card Top() {
        return cards.Last();
    }

    public void Push(Card c) {
        cards.Add(c);
    }

    public Card[] Reset() {
        Card top = cards.Last(); //or last
        cards.Remove(top); //remove top
        Card[] cardsArray = cards.ToArray(); //make array excluding top
        cards.Clear(); //clear all remaining
        cards.Add(top); //read top
        return cardsArray; //return array without top
    }

    public bool IsEmpty() {
        return !cards.Any();
    }

}
