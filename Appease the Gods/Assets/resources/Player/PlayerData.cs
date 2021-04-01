using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string State;
    public float MovementSpeed;
    public float Health = 100.0f;
    public int Phase = 0;
    public bool PickaxeBroken = true;
    public bool AxeBroken = true;
    
    public InventoryItem[] Inventory = new InventoryItem[] {new InventoryItem("Wood", 0, -1, -1, -1, -1, "Resource"),new InventoryItem("Stone", 0, -1, -1, -1, -1, "Resource"),new InventoryItem("Metal", 0, -1, -1, -1, -1, "Resource"),new InventoryItem("None", -1, -1, -1, -1, -1, "None"),new InventoryItem("None", -1, -1, -1, -1, -1, "None")};

    void Start()
    {
        SetState("Idle");
        MovementSpeed = 0.112f;
        SetPhase(0);
    }

    public void SetState(string newState)
    {
        State = newState;
    }

    public void UpdateResource(string type, int count)
    {
        switch(type)
        {
            case "Wood":
                Inventory[0].Count += count;
                break;
            case "Stone":
                Inventory[1].Count += count;
                break;
            case "Metal":
                Inventory[2].Count += count;
                break;
        }
    }

    public void UpgradeTool(string tool)
    {
        switch(tool)
        {
            case "Pickaxe":
                switch(Inventory[3].Name)
                {
                    case "None":
                        Inventory[3] = new InventoryItem("WoodPickaxe", 1, 1, 2, 1, 25, "Wood");
                        break;
                    case "Wood":
                        Inventory[3] = new InventoryItem("StonePickaxe", 1, 1, 4, 2, 50, "Stone");
                        break;
                    case "Stone":
                        Inventory[3] = new InventoryItem("MetalPickaxe", 1, 1, 9, 3, 80, "Metal");
                        break;
                }
                break;
            case "Axe":
                switch(Inventory[4].Name)
                {
                    case "None":
                        Inventory[4] = new InventoryItem("WoodAxe", 1, 3, 1, 1, 25, "Wood");
                        break;
                    case "Wood":
                        Inventory[4] = new InventoryItem("StoneAxe", 1, 5, 1, 1, 50, "Stone");
                        break;
                    case "Stone":
                        Inventory[4] = new InventoryItem("MetalAxe", 1, 9, 1, 1, 80, "Metal");
                        break;
                }
                break;
        }
    }

    public void RepairTool(string tool)
    {
        switch(tool)
        {
            case "Pickaxe":
                switch(Inventory[3].Type)
                {
                    case "Wood":
                        Inventory[3].Durability = 25;
                        break;
                    case "Stone":
                        Inventory[3].Durability = 50;
                        break;
                    case "Metal":
                        Inventory[3].Durability = 80;
                        break;
                }
                break;
            case "Axe":
                switch(Inventory[4].Type)
                {
                    case "Wood":
                        Inventory[4].Durability = 25;
                        break;
                    case "Stone":
                        Inventory[4].Durability = 50;
                        break;
                    case "Metal":
                        Inventory[4].Durability = 80;
                        break;
                }
                break;
        }
    }

    public bool CheckResources(int numWood, int numStone, int numMetal)
    {
        if(Inventory[0].Count >= numWood && Inventory[1].Count >= numStone && Inventory[2].Count >= numMetal)
        {
            return true;
        }

        return false;
    }

    public void UpdateHealth(int amount)
    {
        Health += amount;
        SendMessage("UpdateHealth");
    }

    public void SetPhase(int phase)
    {
        Phase = phase;
        transform.Find("HUD").SendMessage("UpdatePhase");
    }

}
