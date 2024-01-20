using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    public GameObject item;
    public Sprite image;

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

    public void UpdateSlot()
    {
        if(item == null) { image = null; return; }
        image = item.GetComponent<Item>().image;
    }
}
