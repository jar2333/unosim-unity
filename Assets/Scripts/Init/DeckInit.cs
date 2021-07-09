using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckInit : MonoBehaviour
{

    public int playerNumber;
    public GameObject cardPrefab;
    public GameObject discardPilePrefab;
    public GameObject drawPilePrefab;

    public int[] occurrences;
    public Sprite[] sprites;
    public Type type;
    public Action action;

    private List<Card> deck;

    public Connectivity fieldConnectivity;

    void Start() {
        InitDeck();
        InitDraw();
        InitHands();
        InitDiscard();
        FieldManager.instance.FirstTurnDraws();
        FieldManager.instance.SpawnCurrentHand();
    }

    void InitDeck() {
        deck = new List<Card>();
        for (int i = 0; i < sprites.Length; i++) {
            int x = 3;
            //int x = occurrences[i];
            for (int j = 0; j < x; j++) { //for some reason referencing occurrences array here crashes Unity. Huh?
                deck.Add(new Card(new Type[] {type}, new Action[] {action}, sprites[i]));
            }
        }
    }

    void InitHands() {
        for (int i = 1; i <= playerNumber; i++) {
            GameObject hand = new GameObject($"Hand {i}");
            hand.transform.SetParent(gameObject.transform);
            HandWrapper wrapper = hand.AddComponent(typeof(HandWrapper)) as HandWrapper;
            wrapper.cardPrefab = cardPrefab;

            FieldManager.instance.AddHand(wrapper);
        }
        FieldManager.instance.SetCurrentHand();
    }

    void InitDiscard()   {
        GameObject discardPile = Instantiate(discardPilePrefab);
        discardPile.transform.SetParent(gameObject.transform);
        DiscardPileWrapper wrapper = discardPile.GetComponent<DiscardPileWrapper>();
        wrapper.SetFieldConnectivity = fieldConnectivity;

        FieldManager.instance.SetDiscardPileWrapper = wrapper;
    }

    void InitDraw() {
        GameObject drawPile = Instantiate(drawPilePrefab);
        drawPile.transform.SetParent(gameObject.transform);
        DrawPileWrapper wrapper = drawPile.GetComponent<DrawPileWrapper>();
        wrapper.FillDraw(deck.ToArray());

        FieldManager.instance.SetDrawPileWrapper = wrapper;
    }

}
