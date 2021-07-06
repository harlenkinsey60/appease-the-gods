using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPauseUI : MonoBehaviour
{
    public GameObject PauseUICanvas;
    private GameObject ResumeButton;
    private GameObject QuitButton;
    private GameObject VolumeSlider;
    private PlayerSoundManager PlayerSoundManager;
    private bool HideUI;

    PlayerState PlayerState;

    // Getters and Setters

    public bool GetHideUI()
    {
        return HideUI;
    }

    public void SetHideUI(bool hideUI)
    {
        HideUI = hideUI;
        UpdateUI();
        PlayerSoundManager.PlaySound("UIClick");
    }
    
    // Updates UI
    
    public void UpdateUI()
    {
        // Updates visibilty of PauseUI

        if(HideUI == true)
        {
            PauseUICanvas.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            PauseUICanvas.SetActive(true);
            Time.timeScale = 0.0f;

            // if playerprefs has volume key set slider to correct value

            if(PlayerPrefs.HasKey("Volume"))
            {
                VolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
            }
        }
    }

    // Button and slider event listener methods

    private void ResumeGame()
    {
        SetHideUI(true);
        PlayerState.SetState("Idle");
    }

    private void UpdateVolume()
    {
        PlayerSoundManager.ChangeVolume(VolumeSlider.GetComponent<Slider>().value);
        PlayerSoundManager.PlaySound("UIClick");
    }

    private void QuitGame()
    {
        PlayerSoundManager.PlaySound("UIClick");
        Application.Quit();
    }

    // monobehaviour methods

    void Start()
    {

        //Dependencies

        ResumeButton = PauseUICanvas.transform.Find("ResumeButton").gameObject;
        QuitButton = PauseUICanvas.transform.Find("QuitButton").gameObject;
        VolumeSlider = PauseUICanvas.transform.Find("VolumeSlider").gameObject;
        PlayerSoundManager = GetComponent<PlayerSoundManager>();
        PlayerState = GetComponent<PlayerState>();

        //Event listeners

        ResumeButton.GetComponent<Button>().onClick.AddListener(ResumeGame);
        QuitButton.GetComponent<Button>().onClick.AddListener(QuitGame);
        VolumeSlider.GetComponent<Slider>().onValueChanged.AddListener(delegate {UpdateVolume(); });

        // Initializes UI
        SetHideUI(true);
        UpdateUI();

    }
}
