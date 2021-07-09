using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FieldManager : MonoBehaviour
{

    public int initialDrawAmount;

    private List<HandWrapper> playerHandWrappers = new List<HandWrapper>();
    private HandWrapper currentHandWrapper;

    private DiscardPileWrapper spawnedDiscardPileWrapper;
    public DiscardPileWrapper SetDiscardPileWrapper {set {spawnedDiscardPileWrapper = value;}}

    private DrawPileWrapper spawnedDrawPileWrapper;
    public DrawPileWrapper SetDrawPileWrapper {set {spawnedDrawPileWrapper = value;}}

    public static FieldManager instance;

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    public void AddHand(HandWrapper hand) {
        playerHandWrappers.Add(hand);
    }

    public void SetCurrentHand() {
        currentHandWrapper = playerHandWrappers.First();
    }

    //Draw from DrawPile methods
    public void FirstTurnDraws() {
        DrawToAllHands(initialDrawAmount);
        DrawToDiscard();
    }

    public void SpawnCurrentHand() {
        foreach (var hand in playerHandWrappers) {
            hand.ClearSpawned();
        }
        currentHandWrapper.SpawnHand();
    }

    public void DrawToCurrentHand(int amount) {
        DrawToHand(currentHandWrapper, amount);
    }

    public void DrawToAllHands(int amount) {
        foreach (var hand in playerHandWrappers) {
            DrawToHand(hand, amount);
        }
    }

    public void DrawToHand(HandWrapper h, int amount) {
        List<Card> toAdd = new List<Card>();
        for (int i = 0; i < amount; i++) { //draws amount of card to each hand
            Card drawn = spawnedDrawPileWrapper.Draw();
            if (drawn != null) { //if, after reset, drawpile is still, it returns a null
                toAdd.Add(drawn); 
            }
            else {
                Debug.Log("Reset did not bring new cards to draw");
            }
        }
        h.FillHand(toAdd.ToArray());
    }

    public void DrawToDiscard() {
        Card drawnCard = spawnedDrawPileWrapper.Draw();
        if (drawnCard != null) { //really not needed, given this is only called on Awake...
            spawnedDiscardPileWrapper.ForcePlayCard(drawnCard);
        }
        else {
            Debug.Log("Reset did not bring new cards to draw");
        }
    }

    public void ResetDiscard() {
        spawnedDrawPileWrapper.FillDraw(spawnedDiscardPileWrapper.Reset());
    }
}
