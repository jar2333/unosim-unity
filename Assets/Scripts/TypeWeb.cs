using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeWeb
{

    private Type[][] defaultWeb = new Type[][] 
    {
        new Type[] {Type.ZERO},
        new Type[] {Type.ONE},
        new Type[] {Type.TWO},
        new Type[] {Type.THREE},
        new Type[] {Type.FOUR},
        new Type[] {Type.FIVE},
        new Type[] {Type.SIX},
        new Type[] {Type.SEVEN},
        new Type[] {Type.EIGHT},
        new Type[] {Type.NINE},
        new Type[] {Type.SKIP},
        new Type[] {Type.REVERSE},
        new Type[] {Type.DRAWTWO},
        new Type[] {Type.RED},
        new Type[] {Type.BLUE},
        new Type[] {Type.GREEN},
        new Type[] {Type.YELLOW},
        new Type[] {Type.WILD, Type.RED, Type.BLUE, Type.GREEN, Type.YELLOW},
        new Type[] {Type.DRAWFOUR, Type.RED, Type.BLUE, Type.GREEN, Type.YELLOW}
    };

    private Dictionary<Type, Type[]> web = new Dictionary<Type, Type[]>();
    public Dictionary<Type, Type[]> GetWeb {get {return web;}}

    public TypeWeb() {
        Initialize(defaultWeb);
    }

    public TypeWeb(Type[][] range) {
        Initialize(range);
    }

    private void Initialize(Type[][] range) {
        for(int i = 0; i < 18; i++) { //19 Types total
            web.Add((Type)i, range[i]); 
        }
    }


}
