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
    [SerializeField] private Item oldItem;
    private int numberOfSlots;
    private int slotIndex;

    private GameObject clothes;
    [SerializeField] private GameObject playerClothesParent;

    private void Start()
    {
        numberOfSlots = System.Enum.GetNames(typeof(OutfitSlot)).Length; //get the number of the outfit enum slots
        currentOutfit = new Item[numberOfSlots]; //make the empty outfit array with according number of elements
    }

    public void Wear(Item newItem)
    {
        clothes = playerClothesParent.transform.GetChild(newItem.childIndex).gameObject; //find the GameObject reference using item's child index
        clothes.SetActive(true); //enable it's GameObject component of the Player object
        slotIndex = (int)newItem.outfitSlot; //get the int value from the item's enum slot index

        if (currentOutfit[slotIndex] != null) //if on according clothes slot there is an item already
        {
            oldItem = currentOutfit[slotIndex]; //store the old item
            TakeOff(oldItem);
        }

        currentOutfit[slotIndex] = newItem; //equip the item to the according outfit slot
        GameManager.instance.score += newItem.itemScore; //add the equipped item score value to the current score
    }

    public void TakeOff(Item currentItem)
    {
        clothes = playerClothesParent.transform.GetChild(currentItem.childIndex).gameObject; //find the GameObject reference using item's child index
        clothes.SetActive(false); //disable it's GameObject component of the Player object
        GameManager.instance.score -= currentItem.itemScore; //subtract the undressed item's item score value from the total score value
    }
}
