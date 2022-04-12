using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitManager : MonoBehaviour
{
    #region Singleton

    public static OutfitManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public Item[] currentOutfit;
    private int slotIndex;

    [SerializeField] private GameObject clothes;
    [SerializeField] private GameObject oldClothes;
    [SerializeField] private GameObject playerClothesParent;

    public void Wear(Item newItem)
    {
        clothes = playerClothesParent.transform.GetChild(newItem.childIndex).gameObject; //find the GameObject reference using item's child index
        slotIndex = (int)newItem.outfitSlot; //get the int value from the item's enum slot index
        clothes.SetActive(true); //enable it's GameObject component of the Player object

        if (currentOutfit[slotIndex] != null) //if the needed slot is occupied
        {
            TakeOff(currentOutfit[slotIndex]); //disable the current to make the new one visible

            if(newItem == currentOutfit[slotIndex]) //if the new item is the same as the current one
            {
                currentOutfit[slotIndex] = null; //clear out the slot
                return; //skip the rest of the method
            }
        }
        
        currentOutfit[slotIndex] = newItem; //equip the item to the according outfit slot
        GameManager.instance.score += newItem.itemScore; //add the equipped item score value to the current score
    }

    public void TakeOff(Item currentItem)
    {
        oldClothes = playerClothesParent.transform.GetChild(currentItem.childIndex).gameObject; //find the GameObject reference using item's child index
        oldClothes.SetActive(false); //disable it's GameObject component of the Player object
        Debug.Log("kurac");
        GameManager.instance.score -= currentItem.itemScore; //subtract the undressed item's item score value from the total score value
    }
}