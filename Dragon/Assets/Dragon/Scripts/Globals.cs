using UnityEngine;
using System.Collections;

public static class Globals {

    // DEFINE GLOBAL VARIABLS AND ENUMERATIONS HERE
    public enum TAGS
    {
        Player  = "Player",     // There should only be 1 item tagged as this, EVER.
        Enemey  = "Enemey",     // ONLY DAMAGING NPC's!!!
        Item    = "Item",       // This covers COINS too!!!
        World   = "World"       // Ground, caves, towers
    }

    
}
