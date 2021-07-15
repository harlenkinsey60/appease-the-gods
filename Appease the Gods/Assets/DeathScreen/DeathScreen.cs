using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    PlayerState PlayerState;
    Button RespawnButton;
    Button ExitButton;

    void Start()
    {
        PlayerState = GameObject.Find("Player").GetComponent<PlayerState>();
        RespawnButton = transform.Find("Canvas").Find("RespawnButton").GetComponent<Button>();
        ExitButton = transform.Find("Canvas").Find("ExitButton").GetComponent<Button>();

        RespawnButton.onClick.AddListener(RespawnOnClick);
        ExitButton.onClick.AddListener(ExitOnClick);
    }

    void RespawnOnClick()
    {
        PlayerState.Respawn();
    }

    void ExitOnClick()
    {
        Debug.Log("Save and Load Functionality Needs to be Implemented...");
    }
}
