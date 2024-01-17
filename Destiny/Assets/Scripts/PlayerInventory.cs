using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform weaponHolder;

    public GameObject equippedWeapon;
    public GameObject kinetic;
    public GameObject special;
    public GameObject heavy;

    public GameObject[] kineticInventory = new GameObject[9];
    public GameObject[] specialInventory = new GameObject[9];
    public GameObject[] heavyInventory = new GameObject[9];
    public GameObject[] helmetInventory = new GameObject[9];
    public GameObject[] chestplateInventory = new GameObject[9];
    public GameObject[] glovesInventory = new GameObject[9];
    public GameObject[] legsInventory = new GameObject[9];
    public GameObject[] bootsInventory = new GameObject[9];
    public GameObject[] necklaceInventory = new GameObject[9];

    public Item redGun;
    public Item blueGun;
    public Item purpleGun;

    private void Start()
    {
        PickUp(redGun);
        PickUp(blueGun);
        PickUp(purpleGun);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Equip(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Equip(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Equip(2);
        }
    }

    private void Equip(int index)
    {
        GameObject newWeapon = null;
        
        switch (index) {
            case 0:
                if(equippedWeapon == kinetic) { return; }
                equippedWeapon = kinetic;
                if (weaponHolder.childCount > 0) { Destroy(weaponHolder.GetChild(0).gameObject); }
                newWeapon = Instantiate(equippedWeapon.GetComponent<Gun>().item.prefab, weaponHolder) as GameObject;

                break;
            case 1:
                if (equippedWeapon == special) { return; }
                equippedWeapon = special;
                if (weaponHolder.childCount > 0) { Destroy(weaponHolder.GetChild(0).gameObject); }
                newWeapon = Instantiate(equippedWeapon.GetComponent<Gun>().item.prefab, weaponHolder) as GameObject;

                break;
            case 2:
                if (equippedWeapon == heavy) { return; }
                equippedWeapon = heavy;
                if (weaponHolder.childCount > 0) { Destroy(weaponHolder.GetChild(0).gameObject); }
                newWeapon = Instantiate(equippedWeapon.GetComponent<Gun>().item.prefab, weaponHolder) as GameObject;

                break;
            default:
                break;
        }
    }

    public void PickUp(Item item)
    {
        GameObject newItem = item.prefab;
        newItem.GetComponent<Gun>().itemLevel = Random.Range(1, 50);
        if(item.itemType == Item.type.Kinetic)
        {
            kinetic = newItem;
        }
        else if(item.itemType == Item.type.Special)
        {
            special = newItem;
        }
        else if(item.itemType == Item.type.Heavy)
        {
            heavy = newItem;
        }
    }
}