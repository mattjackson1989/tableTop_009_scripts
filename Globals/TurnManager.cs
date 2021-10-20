using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TurnManager 
{
    public static GenericCreature CurrentCreaturesTurn;
    public static int CurrentCreaturesTurnIndex;
    public static List<GameObject> CurrentListOfCreatures;
    public static int Round = 0;
}
