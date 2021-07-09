using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPileInput : MonoBehaviour
{
    void OnMouseDown() {
        FieldManager.instance.DrawToCurrentHand(1);
        FieldManager.instance.SpawnCurrentHand();
    } 
}
