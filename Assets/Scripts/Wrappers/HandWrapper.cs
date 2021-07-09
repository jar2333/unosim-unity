using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandWrapper : MonoBehaviour
{
    public GameObject cardPrefab;

    private List<Card> hand;
    private List<GameObject> spawnedCards;

    void Awake() {
        hand = new List<Card>();
        spawnedCards = new List<GameObject>();
    }

    void SpawnCard(Card c, Vector3 pos) {
        GameObject cardObject = Instantiate(cardPrefab);

        cardObject.transform.position = pos;
        cardObject.transform.SetParent(gameObject.transform);
        cardObject.GetComponent<CardWrapper>().SetCard(c);

        CardInput input = cardObject.GetComponent<CardInput>();
        input.SetDefaultPosition = pos;
        input.ResetPosition();

        spawnedCards.Add(cardObject);
    }

    public void SpawnHand() {
        ClearSpawned();
        Card[] handArray = hand.ToArray();
        for (int i = 0; i < handArray.Length; i++) {
            SpawnCard(handArray[i], new Vector3(-1 * handArray.Length + 2 * (i + 0.5f), -2, 0));
        }
    }

    public void ClearSpawned() {
        foreach (var ob in spawnedCards) {
            Destroy(ob);
        }
        spawnedCards.Clear();
    }

    public void FillHand(Card[] cards) {
        foreach (Card c in cards) {
            hand.Add(c);
        }
    }

    public void RemoveCard(Card c) {
        hand.Remove(c);
        ClearSpawned();
        SpawnHand();
    }

    public void InitHand(Card[] cards) { //deprecated when using FieldManager which requires separate fillhand and spawnhand calls
        FillHand(cards);
        SpawnHand();
    }
    
}
