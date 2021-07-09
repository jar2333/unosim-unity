using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DrawPile
{

    private List<Card> pile;

    public int Length {get {return pile.Count;}}

    public DrawPile() {
        pile = new List<Card>();
    }
    
    public void Shuffle() {
        var count = pile.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = Random.Range(i, count);
            var tmp = pile[i];
            pile[i] = pile[r];
            pile[r] = tmp;
        }
    }

    public void Fill(Card[] cards) {
        foreach (Card c in cards) {
            pile.Add(c);
        }
    }

    public Card Top() {
        return pile.First();
    }

    public Card Pop() {
        if (IsEmpty()) {
            return null;
        }
        Card c = pile.First();
        pile.RemoveAt(0);
        Debug.Log(Length);
        return c;
    }

    public bool IsEmpty() {
        return !pile.Any();
    }

}
