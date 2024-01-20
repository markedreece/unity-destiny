using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public PlayerInventory playerInventory;

    public GameObject mainSlot;
    public GameObject[] sideSlots = new GameObject[9];

    private void Awake()
    {
        mainSlot = transform.GetChild(0).gameObject;

        for(int i = 1; i < transform.childCount; i++)
        {
            sideSlots[i - 1] = transform.GetChild(i).gameObject;
        }
    }

    public void UpdateSlots()
    {
        if(mainSlot != null)
        {
        }
        foreach(GameObject o in sideSlots)
        {
            if(o.GetComponent<SlotScript>().item != null)
            {
            }
        }
    }
}