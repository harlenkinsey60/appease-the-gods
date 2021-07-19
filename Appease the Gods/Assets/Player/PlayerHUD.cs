using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    // UI Dependencies

    private GameObject HUD;
    private GameObject HealthBar;
    private GameObject WoodCount;
    private GameObject StoneCount;
    private GameObject MetalCount;

    private GameObject TimerText;


    // Variables

    private int Phase;
    private float Timer;
    private float[] PhaseTimes = new float[] {180.0f, 120.0f, 60.0f};
    private float Health;
    PlayerState PlayerState;
    public GameObject DeathScreen;
    
    [HideInInspector]
    public SlotItem[] InventorySlots;


    // Getters and Setters

    public int GetPhase()
    {
        return Phase;
    }
    public void SetPhase(int phase)
    {
        Phase = phase;
        Timer = PhaseTimes[phase];
        TimerText.GetComponent<Text>().text = (Mathf.FloorToInt(PhaseTimes[phase] / 60.0f)).ToString() + ":" + (Mathf.FloorToInt(PhaseTimes[phase] % 60.0f).ToString());
    }

    public void SetWoodCount(int woodCount)
    {
        WoodCount.GetComponent<Text>().text = woodCount.ToString();
    }

    public void SetStoneCount(int stoneCount)
    {
        StoneCount.GetComponent<Text>().text = stoneCount.ToString();
    }

    public void SetMetalCount(int metalCount)
    {
        MetalCount.GetComponent<Text>().text = metalCount.ToString();
    }

    // Inventory slot interface methods

    public void SetAxeSprite(Sprite sprite)
    {

        // Finds axe in slots if exists and sets sprite

        foreach( SlotItem slot in InventorySlots ) {
            
            if(slot.GetName() == "Axe"){

                slot.SetSprite(sprite);
                return;
            }

        }

        // If slot with axe doesnt exist, then sets sprite of first available slot

        foreach( SlotItem slot in InventorySlots ) {
            
            if(slot.GetName() == ""){
                
                slot.SetSprite(sprite);
                return;
            }

        }
    }

    public void SetAxeDurability(int durability)
    {

        // Finds slot with pickaxe and sets durability

        foreach( SlotItem slot in InventorySlots ) {
            
            if(slot.GetName() == "Axe"){

                slot.SetDurability(durability);
                return;  
            }
        }
    }

    public void SetPickaxeSprite(Sprite sprite)
    {

        // Finds pickaxe in slots if exists and sets sprite

        foreach( SlotItem slot in InventorySlots ) {
            
            if(slot.GetName() == "Pickaxe"){

                slot.SetSprite(sprite);
                return;
            }

        }
        
        // If slot with pickaxe doesnt exist, then sets sprite of first available slot

        foreach( SlotItem slot in InventorySlots ) {
            
            if(slot.GetName() == ""){
                
                slot.SetSprite(sprite);
                return;
            }
        }
    }

    public void SetPickaxeDurability(int durability)
    {

        // Finds slot with pickaxe and sets durability

        foreach( SlotItem slot in InventorySlots ) {
            
            if(slot.GetName() == "Pickaxe"){

                slot.SetDurability(durability);
                return;

            }
        }
    }

    public float GetHealth()
    {
        return Health;
    }

    public void SetHealth(float health)
    {
        Health = (health < 0.0f) ? 0.0f : health;

        // Sets scale of HealthBar based on health

        HealthBar.transform.localScale = new Vector3(0.5f * (Health / 100.0f), 0.3f, 1.0f);

        // Moves HealthBar so that it correctly overlaps HealthBarBacking

        HealthBar.transform.localPosition = new Vector3(-527.0f - (Mathf.Abs(Health - 100.0f) * 1.23f),-235.0f, 0.0f);

        if(Health == 0.0f)
        {
            DeathScreen.SetActive(true);
            PlayerState.SetState("Dead");
        }
    }

    public void SetSelected(int selected)
    {
        Color BaseColor = new Color(1,1,1,1);
        Color SelectedColor = new Color(0,0,0,1);
        
        for(int i = 0; i < InventorySlots.Length; i++)
        {
            InventorySlots[i].transform.Find("Backing").GetComponent<Image>().color = (i == selected) ? SelectedColor : BaseColor;
        }
    }

    // Monobehavior Functions

    void Start()
    {
        HUD = transform.Find("HUD").gameObject;
        HealthBar = HUD.transform.Find("HealthBar").gameObject;
        WoodCount = HUD.transform.Find("WoodCount").gameObject;
        StoneCount = HUD.transform.Find("StoneCount").gameObject;
        MetalCount = HUD.transform.Find("MetalCount").gameObject;
        TimerText = HUD.transform.Find("TimerPanel").Find("TimerText").gameObject;

        InventorySlots = FindObjectsOfType<SlotItem>();

        PlayerState = GetComponent<PlayerState>();

        Phase = 0;
        Timer = PhaseTimes[0];
        SetHealth(100.0f);
    }

    void Update()
    {
        // Updates Timer

        Timer -= Time.deltaTime;
        TimerText.GetComponent<Text>().text = (Mathf.FloorToInt(Timer / 60.0f)).ToString() + ":" + (Mathf.FloorToInt(Timer % 60.0f).ToString());
    }
}
