using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public enum ItemType
{
    Equipable,
    Consumable,
    Resource
}

public enum ConsumableType
{
    Health,
    Hunger,
    Speed
}
[Serializable]
public class ItemDateConsumable
{
    public ConsumableType Type;
    public float value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item")]
public class ItemDate : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;
    public Sprite icon;
    public GameObject dropPrefabs;

    [Header("Stacking")]
    public bool canStack;
    public int maxStackAmount;

    [Header("Consumable")]
    public ItemDateConsumable[] consumables;

    [Header("Equip")]
    public GameObject equipPrefab;
}
