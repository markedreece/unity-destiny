using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{

    public GameObject item;

    public PlayerInventory playerInventory;

    public void SwapTo()
    {
        if(item.GetComponent<Item>().itemType == Item.type.Kinetic)
        {
            GameObject tempItem = playerInventory.kinetic;
            playerInventory.kinetic = item;
            item = tempItem;
        }
    }
}
