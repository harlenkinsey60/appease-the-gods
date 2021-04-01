using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUDModel : MonoBehaviour
{
    Text WoodAmount;
    Text StoneAmount;
    Text MetalAmount;
    Text TimerText;
    Image PickaxeSlot;
    Image AxeSlot;
    Transform HealthBar;

    PlayerData PlayerData;

    float TimeLeft;

    void Start()
    {
        WoodAmount = transform.Find("WoodAmount").GetComponent<Text>();
        StoneAmount = transform.Find("StoneAmount").GetComponent<Text>();
        MetalAmount = transform.Find("MetalAmount").GetComponent<Text>();
        TimerText = transform.Find("TimerPanel").Find("TimerText").GetComponent<Text>();
        PickaxeSlot = transform.Find("PickaxeSlot").GetComponent<Image>();
        AxeSlot = transform.Find("AxeSlot").GetComponent<Image>();
        HealthBar = transform.Find("HealthBar");

        PlayerData = transform.parent.GetComponent<PlayerData>();

    }

    void Update()
    {

        TimeLeft -= Time.deltaTime;

//
// Updates Timer View
//
        if(PlayerData.State != "Dead" && TimeLeft > 0.0f)
        {
            if((int)(TimeLeft % 60.0f) < 10)
            {
                TimerText.text = ((int)Mathf.Floor(TimeLeft/60.0f)).ToString() + ":0" + ((int)(TimeLeft % 60.0f)).ToString();
            }
            else
            {
                TimerText.text = ((int)Mathf.Floor(TimeLeft/60.0f)).ToString() + ":" + ((int)(TimeLeft % 60.0f)).ToString();
            }
        }

    }

    public void UpdateHealth()
    {
        HealthBar.localScale = new Vector2((PlayerData.Health/100.0f) * 0.5f, HealthBar.localScale.y);
        HealthBar.localPosition = new Vector2(-527.0f - (128.0f - (128.0f * (PlayerData.Health/100.0f))), HealthBar.localPosition.y);
    }

    public void UpdateResources()
    {
        WoodAmount.text = PlayerData.Inventory[0].Count.ToString();
        StoneAmount.text = PlayerData.Inventory[1].Count.ToString();
        MetalAmount.text = PlayerData.Inventory[2].Count.ToString();
    }

    public void UpdatePhase()
    {
        TimeLeft = 180.0f - (PlayerData.Phase * 60.0f);
    }

}

