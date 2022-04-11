using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item item;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))  //when player collides with a piece of clothing
    //    {
    //        WearItem();
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))  //when player collides with a piece of clothing
        {
            GameManager.instance.collectedPickup = true;
            WearItem();
        }
    }

    public void WearItem()
    {
        Debug.Log(item.itemName + " is now worn");
        OutfitManager.instance.Wear(item); //equip the picked-up item
        Destroy(gameObject); //remove the clothes object
    }
}
