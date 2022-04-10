using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wear", menuName = "Clothes")]
public class Item : ScriptableObject
{
    public string itemName = "New Wear";
    public int childIndex; //object index number in player clothes parent object

    public int itemScore;
    public OutfitSlot outfitSlot;
}

public enum OutfitSlot { Torso, Legs, Feet}
