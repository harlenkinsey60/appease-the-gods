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
    private GameObject AxeSlot;
    private GameObject PickaxeSlot;
    private GameObject AxeSlotBacking;
    private GameObject PickaxeSlotBacking;
    private GameObject TimerText;
    private GameObject AxeDurabilityBar;
    private GameObject PickaxeDurabilityBar;

    // Variables
    private int Phase;
    private float Timer;
    private float[] PhaseTimes = new float[] {180.0f, 120.0f, 60.0f};
    private float Health;


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

    public void SetAxeSprite(string spritePath)
    {
        AxeSlot.GetComponent<Image>().sprite = Resources.Load<Sprite>(spritePath);
    }

    public void SetAxeDurability(int durability)
    {
        AxeDurabilityBar.transform.localScale = new Vector3(0.192f * (durability / 100.0f), 0.192f, 1.0f);
        AxeDurabilityBar.transform.localPosition = new Vector3(612.0f - (Mathf.Abs(durability - 100.0f) * 0.25f),-234.5f, 0.0f);
    }

    public void SetPickaxeSprite(string spritePath)
    {
        PickaxeSlot.GetComponent<Image>().sprite = Resources.Load<Sprite>(spritePath);
    }

    public void SetPickaxeDurability(int durability)
    {
        PickaxeDurabilityBar.transform.localScale = new Vector3(0.192f * (durability / 100.0f), 0.192f, 1.0f);
        PickaxeDurabilityBar.transform.localPosition = new Vector3(519.3105f - (Mathf.Abs(durability - 100.0f) * 0.25f),-234.5f, 0.0f);
    }

    public float GetHealth()
    {
        return Health;
    }
    public void SetHealth(float health)
    {
        Health = health;
        // Sets scale of HealthBar based on health
        HealthBar.transform.localScale = new Vector3(0.5f * (health / 100.0f), 0.3f, 1.0f);
        // Moves HealthBar so that is correctly overlaps HealthBarBacking
        HealthBar.transform.localPosition = new Vector3(-527.0f - (Mathf.Abs(health - 100.0f) * 1.23f),-235.0f, 0.0f);
    }

    public void SetSelected(int selected)
    {
        Color BaseColor = new Color(1,1,1,1);
        Color SelectedColor = new Color(0,0,0,1);
        switch(selected)
        {
            case 0:
                PickaxeSlotBacking.GetComponent<Image>().color = SelectedColor;
                AxeSlotBacking.GetComponent<Image>().color = BaseColor;
                break;
            case 1:
                PickaxeSlotBacking.GetComponent<Image>().color = BaseColor;
                AxeSlotBacking.GetComponent<Image>().color = SelectedColor;
                break;
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
        AxeSlot = HUD.transform.Find("AxeSlot").gameObject;
        PickaxeSlot = HUD.transform.Find("PickaxeSlot").gameObject;
        TimerText = HUD.transform.Find("TimerPanel").Find("TimerText").gameObject;
        AxeDurabilityBar = HUD.transform.Find("AxeDurabilityBar").gameObject;
        PickaxeDurabilityBar = HUD.transform.Find("PickaxeDurabilityBar").gameObject;
        AxeSlotBacking = HUD.transform.Find("AxeSlotBacking").gameObject;
        PickaxeSlotBacking = HUD.transform.Find("PickaxeSlotBacking").gameObject;

        Phase = 0;
        Timer = PhaseTimes[0];
    }

    void Update()
    {
        // Update Timer
        Timer -= Time.deltaTime;
        TimerText.GetComponent<Text>().text = (Mathf.FloorToInt(Timer / 60.0f)).ToString() + ":" + (Mathf.FloorToInt(Timer % 60.0f).ToString());
    }
}
