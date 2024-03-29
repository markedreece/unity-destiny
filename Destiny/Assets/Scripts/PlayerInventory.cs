using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject gm;
    public Transform weaponHolder;

    [Header("Hotbar Items")]
    public GameObject equippedWeapon;
    public GameObject kinetic;
    public GameObject special;
    public GameObject heavy;

    [Header("Inventory items")]
    public GameObject[] kineticInventory = new GameObject[9];
    public GameObject[] specialInventory = new GameObject[9];
    public GameObject[] heavyInventory = new GameObject[9];
    public GameObject[] helmetInventory = new GameObject[9];
    public GameObject[] chestplateInventory = new GameObject[9];
    public GameObject[] glovesInventory = new GameObject[9];
    public GameObject[] legsInventory = new GameObject[9];
    public GameObject[] bootsInventory = new GameObject[9];
    public GameObject[] necklaceInventory = new GameObject[9];

    [Header("UI Elements")]
    public GameObject inventoryUI;
    public GameObject[] itemUI;

    [Header("Gameplay Checks")]
    public bool isInventoryOpen;

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        GetInput();
    }

    private void Init()
    {
        inventoryUI.SetActive(false);
        gm = GameObject.Find("GameManager");
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && kinetic != null)
        {
            Equip(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && special != null)
        {
            Equip(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && heavy != null)
        {
            Equip(2);
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isInventoryOpen) { OpenInventory(); }
            else { CloseInventory(); }
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
                newWeapon = Instantiate(kinetic, weaponHolder) as GameObject;

                break;
            case 1:
                if (equippedWeapon == special) { return; }
                equippedWeapon = special;
                if (weaponHolder.childCount > 0) { Destroy(weaponHolder.GetChild(0).gameObject); }
                newWeapon = Instantiate(special, weaponHolder) as GameObject;

                break;
            case 2:
                if (equippedWeapon == heavy) { return; }
                equippedWeapon = heavy;
                if (weaponHolder.childCount > 0) { Destroy(weaponHolder.GetChild(0).gameObject); }
                newWeapon = Instantiate(heavy, weaponHolder) as GameObject;

                break;
            default:
                break;
        }

        Debug.Log("Weapon Item Level: " + equippedWeapon.GetComponent<Gun>().itemLevel);
    }

    public void PickUp(Item item)
    {
        GameObject newItem = Instantiate(item.prefab, gm.transform.Find("Trash")) as GameObject;
        newItem.GetComponent<Gun>().itemLevel = Random.Range(1, 50);

        if(item.itemType == Item.type.Kinetic)
        {
            if(kinetic == null) { kinetic = newItem; itemUI[0].GetComponent<ItemInventory>().mainSlot.GetComponent<SlotScript>().item = kinetic; }
            else
            {
                for(int i = 0; i < kineticInventory.Length; i++)
                {
                    if(kineticInventory[i] == null)
                    {
                        kineticInventory[i] = newItem;
                        return;
                    }
                }
            }
        }
        else if(item.itemType == Item.type.Special)
        {
            if (special == null) { special = newItem; itemUI[1].GetComponent<ItemInventory>().mainSlot.GetComponent<SlotScript>().item = special; }
            else
            {
                for (int i = 0; i < specialInventory.Length; i++)
                {
                    if (specialInventory[i] == null)
                    {
                        specialInventory[i] = newItem;
                        return;
                    }
                }
            }
        }
        else if(item.itemType == Item.type.Heavy)
        {
            if (heavy == null) { heavy = newItem; itemUI[2].GetComponent<ItemInventory>().mainSlot.GetComponent<SlotScript>().item = heavy; }
            else
            {
                for (int i = 0; i < heavyInventory.Length; i++)
                {
                    if (heavyInventory[i] == null)
                    {
                        heavyInventory[i] = newItem;
                        return;
                    }
                }
            }
        }
    }

    private void OpenInventory()
    {
        foreach (GameObject o in itemUI)
        {
            o.GetComponent<ItemInventory>().UpdateSlots();
        }
        inventoryUI.SetActive(true);
        isInventoryOpen = true;
    }

    private void CloseInventory()
    {
        inventoryUI.SetActive(false);
        isInventoryOpen = false;
    }
}