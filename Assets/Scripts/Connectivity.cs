using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectivity : MonoBehaviour
{
    public TypeWeb web;

    void Awake() {
        web = new TypeWeb(); //just a test with defaults for now, change to transfer from config
    }

    public bool Connects(Card a, Card b) {
        Type[] aTypes = a.CardTypes;
        Type[] bTypes = b.CardTypes;
        Dictionary<Type, Type[]> typeMap = web.GetWeb;
        foreach (Type playedType in aTypes) {
            foreach (Type targetType in bTypes) {
                foreach (Type option in typeMap[playedType]) {
                    if (targetType == option) {
                        return true;
                    }
                }
                
            }
        } 
        return false;
    }
    
}
