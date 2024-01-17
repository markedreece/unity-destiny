using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform weaponHolder;

    public GameObject equippedWeapon;
    public GameObject kineticWeapon;
    public GameObject specialWeapon;
    public GameObject heavyWeapon;

    public GameObject[] kinetic = new GameObject[9];
    public GameObject[] special = new GameObject[9];
    public GameObject[] heavy = new GameObject[9];
    public GameObject[] helmet = new GameObject[9];
    public GameObject[] chestplate = new GameObject[9];
    public GameObject[] gloves = new GameObject[9];
    public GameObject[] legs = new GameObject[9];
    public GameObject[] boots = new GameObject[9];
    public GameObject[] necklace = new GameObject[9];

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
        GameObject newWeapon;
        switch (index) {
            case 0:
                if(equippedWeapon == kineticWeapon) { return; }
                equippedWeapon = kineticWeapon;

                newWeapon = Instantiate(equippedWeapon.GetComponent<Gun>().item.prefab, weaponHolder) as GameObject;

                break;
            case 1:
                if (equippedWeapon == specialWeapon) { return; }
                equippedWeapon = specialWeapon;

                newWeapon = Instantiate(equippedWeapon.GetComponent<Gun>().item.prefab, weaponHolder) as GameObject;

                break;
            case 2:
                if (equippedWeapon == heavyWeapon) { return; }
                equippedWeapon = heavyWeapon;

                newWeapon = Instantiate(equippedWeapon.GetComponent<Gun>().item.prefab, weaponHolder) as GameObject;

                break;
            default:
                break;
        }
    }
}