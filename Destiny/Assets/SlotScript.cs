using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void UpdateSlot()
    {
        if(item == null) { GetComponent<Image>().sprite = null; return; }
        GetComponent<Image>().sprite = item.GetComponent<Gun>().item.image;
    }
}
