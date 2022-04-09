using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Clothes")]
public class Clothes : Item
{
    public int value;
}

public enum WearSlot { Torso, Legs, Feet}
