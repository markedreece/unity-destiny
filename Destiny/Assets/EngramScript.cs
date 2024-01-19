using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngramScript : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        if(item.rarityType == Item.rarity.Common) { GetComponent<Renderer>().material.color = new Color(132, 132, 132); }
        else if(item.rarityType == Item.rarity.Uncommon) { GetComponent<Renderer>().material.color = new Color(0, 255, 0); }
        else if (item.rarityType == Item.rarity.Rare) { GetComponent<Renderer>().material.color = new Color(0, 30, 255); }
        else if (item.rarityType == Item.rarity.Legendary) { GetComponent<Renderer>().material.color = new Color(121, 0, 255); }
        else if (item.rarityType == Item.rarity.Exotic) { GetComponent<Renderer>().material.color = new Color(255, 213, 0); }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("You obtained: " + item.itemName);
            collision.gameObject.GetComponent<PlayerInventory>().PickUp(item);
            Destroy(gameObject);
        }
    }
}