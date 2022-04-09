using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : ScriptableObject
{
    public string itemName;

    public void WearItem(GameObject itemObject)
    {
        itemObject.SetActive(true);
    }
}

