using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{
    private string Name;
    private int Durability;
    private string SpritePath;

    public GameObject ItemImage;
    public GameObject DurabilityBar;

    // Monobehaviour methods

    void Start()
    {
        SetName("");
    }

    // Getters and setters

    public string GetName() {
        return Name;
    }

    public void SetName(string name){
        Name = name;
        UpdateUI();
    }

    public void SetDurability(int durability){
        Durability = durability;
        UpdateUI();
    }

    public void SetSprite(string spritePath){
        SpritePath = spritePath;
        UpdateUI();
    }

    // Updates all slot ui components 

    private void UpdateUI(){
        
        if(Name == ""){
            
            ItemImage.GetComponent<Image>().sprite = null;
            DurabilityBar.SetActive(false);

        } else {

            ItemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(SpritePath);
            DurabilityBar.SetActive(true);
            DurabilityBar.transform.localScale = new Vector3(0.192f * (Durability / 100.0f), 0.192f, 1.0f);
            DurabilityBar.transform.localPosition = new Vector3(0.0f - (Mathf.Abs(Durability - 100.0f) * 0.25f),-20.0f, 0.0f);
        }
    }
}
