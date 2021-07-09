using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    private Type[] cardTypes; 
    private Action[] cardActions;
    private Sprite cardSprite;

    public Type[] CardTypes {get {return cardTypes;}}
    public Action[] CardActions {get {return CardActions;}} 
    public Sprite CardSprite {get {return cardSprite;}}

    public Card(Sprite sprite) {
        this.cardTypes = new Type[] {Type.RED, Type.REVERSE};
        this.cardActions = new Action[] {Action.REVERSE};
        this.cardSprite = sprite;
    }
    
    public Card(Type[] cardTypes, Action[] cardActions, Sprite cardSprite) {
        this.cardTypes = cardTypes;
        this.cardActions = cardActions; 
        this.cardSprite = cardSprite;
    }

    public override string ToString() {
        return "this is a card!";
    }
}