using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    consumable,
    usable
}

[Serializable]

public class ItemDataConsumable
{
    public float value = 0f;
    public float duration = 0f;
}

public class ItemData : MonoBehaviour
{
    [Header("Info")]
    public string displayName;
    public string description;
    public ItemType type;

    public ItemDataConsumable consumable;
}
