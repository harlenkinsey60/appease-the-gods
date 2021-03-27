using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryItem
{
    public string Name;
    public int Count;
    public int WoodDamage;
    public int StoneDamage;
    public int MetalDamage;
    public int Durability;
    public string Type;

    public InventoryItem(string name, int count, int woodDamage, int stoneDamage, int metalDamage, int durability, string type)
    {
        Name = name;
        Count = count;
        WoodDamage = woodDamage;
        StoneDamage = stoneDamage;
        MetalDamage = metalDamage;
        Durability = durability;
        Type = type;
    }

}
