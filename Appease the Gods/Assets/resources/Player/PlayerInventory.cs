using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerInventory : MonoBehaviour
{
    private int WoodCount;
    private int StoneCount;
    private int MetalCount;
    private int AxeType;
    private int AxeDurability;
    private int PickaxeType;
    private int PickaxeDurability;
    private bool HideUI;
    private int Selected;
    private int[,] AxeUpgradeCosts = new int[,] {{ 20, 0, 0 }, { 20, 40, 0 }, { 20, 40, 60 }};
    private int[,] PickaxeUpgradeCosts = new int[,] {{ 40, 0, 0 }, { 40, 60, 0 }, { 40, 60, 80 }};
    private int[,] AxeRepairCosts = new int[,] {{ 2, 0, 0 }, { 3, 3, 0 }, { 6, 6, 6 }};
    private int[,] PickaxeRepairCosts = new int[,] {{ 2, 0, 0 }, { 4, 4, 0 }, { 6, 8, 8 }};
    private int[,] AppeasePhaseCosts = new int[,] {{ 50, 0, 0 }, { 150, 200, 0 }, { 200, 250, 300 }};
    private string[,] ToolSpritePaths = new string[,] {{"ToolInventorySprites/WoodAxe", "ToolInventorySprites/StoneAxe", "ToolInventorySprites/MetalAxe"}, {"ToolInventorySprites/WoodPickaxe", "ToolInventorySprites/StonePickaxe", "ToolInventorySprites/MetalPickaxe"}};

    private PlayerHUD PlayerHUD;
    private PlayerSoundManager PlayerSoundManager;
    
    public GameObject InventoryUI;
    private GameObject UpgradesTab;
    private GameObject RepairTab;
    private GameObject AppeaseTab;
    private Transform UpgradesCanvas;
    private Transform RepairCanvas;
    private Transform AppeaseCanvas;

//Upgrades Tab

    private GameObject CurrentAxeImage;
    private GameObject NextAxeImage;
    private GameObject CurrentPickaxeImage;
    private GameObject NextPickaxeImage;
    private GameObject Arrow1;
    private GameObject Arrow2;
    private GameObject RequiresText1;
    private GameObject RequiresText2;
    private GameObject AxeWoodIcon;
    private GameObject AxeStoneIcon;
    private GameObject AxeMetalIcon;
    private GameObject PickaxeWoodIcon;
    private GameObject PickaxeStoneIcon;
    private GameObject PickaxeMetalIcon;
    private GameObject AxeWoodCount;
    private GameObject AxeStoneCount;
    private GameObject AxeMetalCount;
    private GameObject PickaxeWoodCount;
    private GameObject PickaxeStoneCount;
    private GameObject PickaxeMetalCount;
    private GameObject AxeUpgradeButton;
    private GameObject PickaxeUpgradeButton;
    private GameObject AxeFullyUpgradedText;
    private GameObject PickaxeFullyUpgradedText;
    private GameObject AxeNothingToUpgradeText;
    private GameObject PickaxeNothingToUpgradeText;

//Repair Tab

    private GameObject AxeImage;
    private GameObject PickaxeImage;
    private GameObject RequiresText1Repair;
    private GameObject RequiresText2Repair;
    private GameObject AxeWoodIconRepair;
    private GameObject AxeStoneIconRepair;
    private GameObject AxeMetalIconRepair;
    private GameObject PickaxeWoodIconRepair;
    private GameObject PickaxeStoneIconRepair;
    private GameObject PickaxeMetalIconRepair;
    private GameObject AxeWoodCountRepair;
    private GameObject AxeStoneCountRepair;
    private GameObject AxeMetalCountRepair;
    private GameObject PickaxeWoodCountRepair;
    private GameObject PickaxeStoneCountRepair;
    private GameObject PickaxeMetalCountRepair;
    private GameObject AxeRepairButton;
    private GameObject PickaxeRepairButton;
    private GameObject AxeNothingToRepairText;
    private GameObject PickaxeNothingToRepairText;

//Appease Tab

    private GameObject ResourcesRequired;
    private GameObject WoodIconAppease;
    private GameObject StoneIconAppease;
    private GameObject MetalIconAppease;
    private GameObject WoodCountAppease;
    private GameObject StoneCountAppease;
    private GameObject MetalCountAppease;
    private GameObject AppeaseButton;

// Start of Getters and Setters

    public void SetWoodCount(int woodCount)
    {
        WoodCount = woodCount;
        UpdateUI();
    }
    public int GetWoodCount()
    {
        return WoodCount;
    }

    public void SetStoneCount(int stoneCount)
    {
        StoneCount = stoneCount;
        UpdateUI();
    }
    public int GetStoneCount()
    {
        return StoneCount;
    }

    public void SetMetalCount(int metalCount)
    {
        MetalCount = metalCount;
        UpdateUI();
    }
    public int GetMetalCount()
    {
        return MetalCount;
    }

    public void SetAxeType(int axeType)
    {
        AxeType = axeType;
        UpdateUI();
    }
    public int GetAxeType()
    {
        return AxeType;
    }
    
    public void SetPickaxeType(int pickaxeType)
    {
        PickaxeType = pickaxeType;
        UpdateUI();
    }
    public int GetPickaxeType()
    {
        return PickaxeType;
    }

    public void SetAxeDurability(int axeDurability)
    {
        AxeDurability = axeDurability;
        UpdateUI();
    }
    public int GetAxeDurability()
    {
        return AxeDurability;
    }

    public void SetPickaxeDurability(int pickaxeDurability)
    {
        PickaxeDurability = pickaxeDurability;
        UpdateUI();
    }
    public int GetPickaxeDurability()
    {
        return PickaxeDurability;
    }

    public void SetHideUI(bool hideUI)
    {
        HideUI = hideUI;
        UpdateUI();
        PlayerSoundManager.PlaySound("UIClick");
    }
    public bool GetHideUI()
    {
        return HideUI;
    }

    public void SetSelected(int selected)
    {
        Selected = selected;
        UpdateUI();
    }
    public int GetSelected()
    {
        return Selected;
    }

// End of Getters and Setters

    void Start()
    {
        WoodCount = 0;
        StoneCount = 0;
        MetalCount = 0;
        AxeType = -1;
        PickaxeType = -1;
        AxeDurability = 0;
        PickaxeDurability = 0;
        HideUI = true;
        Selected = -1;

        PlayerHUD = GetComponent<PlayerHUD>();
        PlayerSoundManager = GetComponent<PlayerSoundManager>();

        UpgradesTab = InventoryUI.transform.Find("Upgrades").gameObject;
        RepairTab = InventoryUI.transform.Find("Repair").gameObject;
        AppeaseTab = InventoryUI.transform.Find("Appease").gameObject;
        UpgradesCanvas = InventoryUI.transform.Find("UpgradesCanvas");
        RepairCanvas = InventoryUI.transform.Find("RepairCanvas");
        AppeaseCanvas = InventoryUI.transform.Find("AppeaseCanvas");

//Upgrades Tab

        CurrentAxeImage = UpgradesCanvas.Find("CurrentAxeImage").gameObject;
        NextAxeImage = UpgradesCanvas.Find("NextAxeImage").gameObject;
        CurrentPickaxeImage = UpgradesCanvas.Find("CurrentPickaxeImage").gameObject;
        NextPickaxeImage = UpgradesCanvas.Find("NextPickaxeImage").gameObject;
        Arrow1 = UpgradesCanvas.Find("Arrow1").gameObject;
        Arrow2 = UpgradesCanvas.Find("Arrow2").gameObject;
        RequiresText1 = UpgradesCanvas.Find("RequiresText1").gameObject;
        RequiresText2 = UpgradesCanvas.Find("RequiresText2").gameObject;
        AxeWoodIcon = UpgradesCanvas.Find("AxeWoodIcon").gameObject;
        AxeStoneIcon = UpgradesCanvas.Find("AxeStoneIcon").gameObject;
        AxeMetalIcon = UpgradesCanvas.Find("AxeMetalIcon").gameObject;
        PickaxeWoodIcon = UpgradesCanvas.Find("PickaxeWoodIcon").gameObject;
        PickaxeStoneIcon = UpgradesCanvas.Find("PickaxeStoneIcon").gameObject;
        PickaxeMetalIcon = UpgradesCanvas.Find("PickaxeMetalIcon").gameObject;
        AxeWoodCount = UpgradesCanvas.Find("AxeWoodCount").gameObject;
        AxeStoneCount = UpgradesCanvas.Find("AxeStoneCount").gameObject;
        AxeMetalCount = UpgradesCanvas.Find("AxeMetalCount").gameObject;
        PickaxeWoodCount = UpgradesCanvas.Find("PickaxeWoodCount").gameObject;
        PickaxeStoneCount = UpgradesCanvas.Find("PickaxeStoneCount").gameObject;
        PickaxeMetalCount = UpgradesCanvas.Find("PickaxeMetalCount").gameObject;
        AxeUpgradeButton = UpgradesCanvas.Find("AxeUpgradeButton").gameObject;
        PickaxeUpgradeButton = UpgradesCanvas.Find("PickaxeUpgradeButton").gameObject;
        AxeFullyUpgradedText = UpgradesCanvas.Find("AxeFullyUpgraded").gameObject;
        PickaxeFullyUpgradedText = UpgradesCanvas.Find("PickaxeFullyUpgraded").gameObject;
        AxeNothingToUpgradeText = UpgradesCanvas.Find("AxeNothingToUpgrade").gameObject;
        PickaxeNothingToUpgradeText = UpgradesCanvas.Find("PickaxeNothingToUpgrade").gameObject;

//Repair Tab

        AxeImage = RepairCanvas.Find("AxeImage").gameObject;
        PickaxeImage = RepairCanvas.Find("PickaxeImage").gameObject;
        RequiresText1Repair = RepairCanvas.Find("RequiresText1").gameObject;
        RequiresText2Repair = RepairCanvas.Find("RequiresText2").gameObject;
        AxeWoodIconRepair = RepairCanvas.Find("AxeWoodIcon").gameObject;
        AxeStoneIconRepair = RepairCanvas.Find("AxeStoneIcon").gameObject;
        AxeMetalIconRepair = RepairCanvas.Find("AxeMetalIcon").gameObject;
        PickaxeWoodIconRepair = RepairCanvas.Find("PickaxeWoodIcon").gameObject;
        PickaxeStoneIconRepair = RepairCanvas.Find("PickaxeStoneIcon").gameObject;
        PickaxeMetalIconRepair = RepairCanvas.Find("PickaxeMetalIcon").gameObject;
        AxeWoodCountRepair = RepairCanvas.Find("AxeWoodCount").gameObject;
        AxeStoneCountRepair = RepairCanvas.Find("AxeStoneCount").gameObject;
        AxeMetalCountRepair = RepairCanvas.Find("AxeMetalCount").gameObject;
        PickaxeWoodCountRepair = RepairCanvas.Find("PickaxeWoodCount").gameObject;
        PickaxeStoneCountRepair = RepairCanvas.Find("PickaxeStoneCount").gameObject;
        PickaxeMetalCountRepair = RepairCanvas.Find("PickaxeMetalCount").gameObject;
        AxeRepairButton = RepairCanvas.Find("AxeRepairButton").gameObject;
        PickaxeRepairButton = RepairCanvas.Find("PickaxeRepairButton").gameObject;
        AxeNothingToRepairText = RepairCanvas.Find("AxeNothingToRepair").gameObject;
        PickaxeNothingToRepairText = RepairCanvas.Find("PickaxeNothingToRepair").gameObject;

//Appease Tab

        ResourcesRequired = AppeaseCanvas.Find("ResourcesRequired").gameObject;
        WoodIconAppease = AppeaseCanvas.Find("WoodIcon").gameObject;
        StoneIconAppease = AppeaseCanvas.Find("StoneIcon").gameObject;
        MetalIconAppease = AppeaseCanvas.Find("MetalIcon").gameObject;
        WoodCountAppease = AppeaseCanvas.Find("WoodCount").gameObject;
        StoneCountAppease = AppeaseCanvas.Find("StoneCount").gameObject;
        MetalCountAppease = AppeaseCanvas.Find("MetalCount").gameObject;
        AppeaseButton = AppeaseCanvas.Find("AppeaseButton").gameObject;

//Click Listeners
        
        UpgradesTab.GetComponent<Button>().onClick.AddListener(() => ChangeTab("Upgrades"));
        RepairTab.GetComponent<Button>().onClick.AddListener(() => ChangeTab("Repair"));
        AppeaseTab.GetComponent<Button>().onClick.AddListener(() => ChangeTab("Appease"));
        AxeUpgradeButton.GetComponent<Button>().onClick.AddListener(UpgradeAxe);
        PickaxeUpgradeButton.GetComponent<Button>().onClick.AddListener(UpgradePickaxe);
        AxeRepairButton.GetComponent<Button>().onClick.AddListener(RepairAxe);
        PickaxeRepairButton.GetComponent<Button>().onClick.AddListener(RepairPickaxe);
        AppeaseButton.GetComponent<Button>().onClick.AddListener(Appease);

        UpdateUI();
    }

    private void UpdateUI()
    {   
        int Phase = PlayerHUD.GetPhase();

        // Updates Counts On All Tabs and checks if player has at least wood pickaxe and axe before trying to update
        
        if(AxeType < 2)
        {
            AxeWoodCount.GetComponent<Text>().text = AxeUpgradeCosts[AxeType + 1, 0].ToString();
            AxeStoneCount.GetComponent<Text>().text = AxeUpgradeCosts[AxeType + 1, 1].ToString();
            AxeMetalCount.GetComponent<Text>().text = AxeUpgradeCosts[AxeType + 1, 2].ToString();
        }

        if(AxeType > -1)
        {
            AxeWoodCountRepair.GetComponent<Text>().text = (AxeRepairCosts[AxeType, 0] * AxeDurability).ToString();
            AxeStoneCountRepair.GetComponent<Text>().text = (AxeRepairCosts[AxeType, 1] * AxeDurability).ToString();
            AxeMetalCountRepair.GetComponent<Text>().text = (AxeRepairCosts[AxeType, 2] * AxeDurability).ToString();
        }

        if(PickaxeType < 2)
        {
            PickaxeWoodCount.GetComponent<Text>().text = PickaxeUpgradeCosts[PickaxeType + 1, 0].ToString();
            PickaxeStoneCount.GetComponent<Text>().text = PickaxeUpgradeCosts[PickaxeType + 1, 1].ToString();
            PickaxeMetalCount.GetComponent<Text>().text = PickaxeUpgradeCosts[PickaxeType + 1, 2].ToString();
        }

        if(PickaxeType > -1)
        {
            PickaxeWoodCountRepair.GetComponent<Text>().text = (PickaxeRepairCosts[PickaxeType, 0] * PickaxeDurability).ToString();
            PickaxeStoneCountRepair.GetComponent<Text>().text = (PickaxeRepairCosts[PickaxeType, 1] * PickaxeDurability).ToString();
            PickaxeMetalCountRepair.GetComponent<Text>().text = (PickaxeRepairCosts[PickaxeType, 2] * PickaxeDurability).ToString();
        }
        
        WoodCountAppease.GetComponent<Text>().text = AppeasePhaseCosts[Phase, 0].ToString();
        StoneCountAppease.GetComponent<Text>().text = AppeasePhaseCosts[Phase, 1].ToString();
        MetalCountAppease.GetComponent<Text>().text = AppeasePhaseCosts[Phase, 2].ToString();

        // Updates Sprites On All Tabs

    // Checks if player has Axe and if it is fully upgraded and shows appropriate objects

        if(AxeType < 2 && AxeType > -1)
        {
            CurrentAxeImage.SetActive(true);
            CurrentAxeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(ToolSpritePaths[0, AxeType]);
            NextAxeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(ToolSpritePaths[0, AxeType + 1]);
        }
        else if (AxeType == 2)
        {
            CurrentAxeImage.SetActive(false);
            NextAxeImage.SetActive(false);
            RequiresText1.SetActive(false);
            AxeWoodIcon.SetActive(false);
            AxeStoneIcon.SetActive(false);
            AxeMetalIcon.SetActive(false);
            AxeWoodCount.SetActive(false);
            AxeStoneCount.SetActive(false);
            AxeMetalCount.SetActive(false);
            AxeUpgradeButton.SetActive(false);
            Arrow1.SetActive(false);
            
            AxeFullyUpgradedText.SetActive(true);
        }
        else if (AxeType == -1)
        {
            CurrentAxeImage.SetActive(false);
            NextAxeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(ToolSpritePaths[0, AxeType + 1]);
        }

    // Checks if player has Pickaxe and if it is fully upgraded and shows appropriate objects

        if(PickaxeType < 2 && PickaxeType > -1)
        {
            CurrentPickaxeImage.SetActive(true);
            CurrentPickaxeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(ToolSpritePaths[1, PickaxeType]);
            NextPickaxeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(ToolSpritePaths[1, PickaxeType + 1]);
        }
        else if (PickaxeType == 2)
        {
            CurrentPickaxeImage.SetActive(false);
            NextPickaxeImage.SetActive(false);
            RequiresText2.SetActive(false);
            PickaxeWoodIcon.SetActive(false);
            PickaxeStoneIcon.SetActive(false);
            PickaxeMetalIcon.SetActive(false);
            PickaxeWoodCount.SetActive(false);
            PickaxeStoneCount.SetActive(false);
            PickaxeMetalCount.SetActive(false);
            PickaxeUpgradeButton.SetActive(false);
            Arrow2.SetActive(false);

            PickaxeFullyUpgradedText.SetActive(true);
        }
        else if (PickaxeType == -1)
        {
            CurrentPickaxeImage.SetActive(false);
            NextPickaxeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(ToolSpritePaths[1, PickaxeType + 1]);
        }

        // Checks if player has Axe and if can be repaired

        if(AxeType > -1)
        {
            AxeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(ToolSpritePaths[0, AxeType]);
        }
        else 
        {
            AxeImage.SetActive(false);
            RequiresText1Repair.SetActive(false);
            AxeWoodIconRepair.SetActive(false);
            AxeStoneIconRepair.SetActive(false);
            AxeMetalIconRepair.SetActive(false);
            AxeWoodCountRepair.SetActive(false);
            AxeStoneCountRepair.SetActive(false);
            AxeMetalCountRepair.SetActive(false);
            AxeRepairButton.SetActive(false);

            AxeNothingToRepairText.SetActive(true);
        }

        if(PickaxeType > -1)
        {
            PickaxeImage.GetComponent<Image>().sprite = Resources.Load<Sprite>(ToolSpritePaths[1, PickaxeType]);
        }
        else
        {
            PickaxeImage.SetActive(false);
            RequiresText2Repair.SetActive(false);
            PickaxeWoodIconRepair.SetActive(false);
            PickaxeStoneIconRepair.SetActive(false);
            PickaxeMetalIconRepair.SetActive(false);
            PickaxeWoodCountRepair.SetActive(false);
            PickaxeStoneCountRepair.SetActive(false);
            PickaxeMetalCountRepair.SetActive(false);
            PickaxeRepairButton.SetActive(false);

            PickaxeNothingToRepairText.SetActive(true);
        }

        // Updates the interactability of buttons on all tabs
        
        if(AxeType > -1 && AxeType < 2 && WoodCount >= AxeUpgradeCosts[AxeType, 0] && StoneCount >= AxeUpgradeCosts[AxeType, 1] && MetalCount >= AxeUpgradeCosts[AxeType, 3])
        {
            AxeUpgradeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            AxeUpgradeButton.GetComponent<Button>().interactable = false;
        }

        if(PickaxeType > -1 && PickaxeType < 2 && WoodCount >= PickaxeUpgradeCosts[PickaxeType, 0] && StoneCount >= PickaxeUpgradeCosts[PickaxeType, 1] && MetalCount >= PickaxeUpgradeCosts[PickaxeType, 3])
        {
            PickaxeUpgradeButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            PickaxeUpgradeButton.GetComponent<Button>().interactable = false;
        }

        if(AxeType > -1 && AxeType < 2 && WoodCount >= AxeRepairCosts[AxeType, 0] && StoneCount >= AxeRepairCosts[AxeType, 1] && MetalCount >= AxeRepairCosts[AxeType, 3])
        {
            AxeRepairButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            AxeRepairButton.GetComponent<Button>().interactable = false;
        }

        if(PickaxeType > -1 && PickaxeType < 2 && WoodCount >= PickaxeRepairCosts[PickaxeType, 0] && StoneCount >= PickaxeRepairCosts[PickaxeType, 1] && MetalCount >= PickaxeRepairCosts[PickaxeType, 3])
        {
            PickaxeRepairButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            PickaxeRepairButton.GetComponent<Button>().interactable = false;
        }

        if(Phase < 2 && WoodCount >= AppeasePhaseCosts[Phase, 0] && StoneCount >= AppeasePhaseCosts[Phase, 1] && MetalCount >= AppeasePhaseCosts[Phase, 2])
        {
            AppeaseButton.GetComponent<Button>().interactable = true;
        }
        else
        {
            AppeaseButton.GetComponent<Button>().interactable = false;
        }

        // Put update held item when axe/pickaxe models acquired
        Debug.Log("PlayerInventory needs held item update code.");

        // Passes PlayerInventory values to PlayerHUD

        PlayerHUD.SetWoodCount(WoodCount);
        PlayerHUD.SetStoneCount(StoneCount);
        PlayerHUD.SetMetalCount(MetalCount);
        
        //Checks if has axe and pickaxe before trying to set sprite

        if(AxeType != -1)
        {
            PlayerHUD.SetAxeSprite(ToolSpritePaths[0, AxeType]);
        }

        if(PickaxeType != -1)
        {
            PlayerHUD.SetPickaxeSprite(ToolSpritePaths[1, PickaxeType]);
        }
        
        // Sets PlayerHUD tool durabilities

        PlayerHUD.SetAxeDurability(AxeDurability);
        PlayerHUD.SetPickaxeDurability(PickaxeDurability);

        // Updates Selected

        if(Selected == 0)
        {
            PlayerHUD.SetSelected(0);
        }
        else
        {
            PlayerHUD.SetSelected(1);
        }

        // Hides UI if HideUI is true

        if(HideUI == true)
        {
            ChangeTab("Upgrades");
            InventoryUI.SetActive(false);
        } else 
        {
            InventoryUI.SetActive(true);
        }
    }

    public void ChangeTab(string tabName)
    {
        switch (tabName)
        {
            case "Upgrades":
                RepairCanvas.gameObject.SetActive(false);
                AppeaseCanvas.gameObject.SetActive(false);
                UpgradesCanvas.gameObject.SetActive(true);
                PlayerSoundManager.PlaySound("UIClick");
                break;
            case "Repair":
                RepairCanvas.gameObject.SetActive(true);
                AppeaseCanvas.gameObject.SetActive(false);
                UpgradesCanvas.gameObject.SetActive(false);
                PlayerSoundManager.PlaySound("UIClick");
                break;
            case "Appease":
                RepairCanvas.gameObject.SetActive(false);
                AppeaseCanvas.gameObject.SetActive(true);
                UpgradesCanvas.gameObject.SetActive(false);
                PlayerSoundManager.PlaySound("UIClick");
                break;
        }
    }

    public void UpgradeAxe()
    {
        if(AxeType < 2)
        {
            SetAxeType(AxeType + 1);
        }
        
        PlayerSoundManager.PlaySound("UIClick");
        UpdateUI();
    }

    public void UpgradePickaxe()
    {
        if(PickaxeType < 2)
        {
            SetPickaxeType(PickaxeType + 1);
        }

        PlayerSoundManager.PlaySound("UIClick");
        UpdateUI();
    }

    public void RepairAxe()
    {
        SetAxeDurability(100);
        PlayerSoundManager.PlaySound("UIClick");
        UpdateUI();
    }

    public void RepairPickaxe()
    {
        SetAxeDurability(100);
        PlayerSoundManager.PlaySound("UIClick");
        UpdateUI();
    }

    public void Appease()
    {
        PlayerHUD.SetPhase(PlayerHUD.GetPhase() + 1);
        PlayerSoundManager.PlaySound("UIClick");
        UpdateUI();
    }
}