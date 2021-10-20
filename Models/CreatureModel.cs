using Assets.Scripts.Globals;
using Assets.Scripts.Models;
using System.Collections.Generic;

public class CreatureModel
{
    public string Name;
    public int Initiative;
    public int Health;
    public int ActionPoint;
    public int Attack;
    public int Defense;
    public int Speed;
    List<ACTIONTYPE> ActionsAllowed;
    List<SpellModel> SpellsAllowed;
}
