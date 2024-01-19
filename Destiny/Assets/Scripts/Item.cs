using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Item")]
public class Item : ScriptableObject
{
    public enum type
    {
        Kinetic,
        Special,
        Heavy,
        Helmet,
        Chestplate,
        Arms,
        Legs,
        Boots,
        Necklace
    };

    public type itemType;

    public enum rarity
    {
        Common,
        Uncommon,
        Rare,
        Legendary,
        Exotic
    };

    public rarity rarityType;

    public string itemName;

    public GameObject prefab;
}