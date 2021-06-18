using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekState : MonoBehaviour
{
    Animator ShrekAnimator;
    ShrekHealth ShrekHealth;
    PlayerSoundManager PlayerSoundManager;
    private string State;

    // Getters and Setters

    public string GetState()
    {
        return State;
    }

    public void SetState(string state)
    {
        State = state;
    }

    // Handles Animations and Updates Necessary Components

    private void HandleState()
    {
        switch(State)
        {
            case "Idle":

                ShrekAnimator.SetBool("IsDancing", true);
                ShrekAnimator.SetBool("IsTPosing", false);

                break;

            case "Decay":

                ShrekAnimator.SetBool("Decay", true);

                break;
        }

        // Handles Death

        if(ShrekHealth.GetHealth() <= 0.0f)
        {
            SetState("Decay");
        }
    }

    public void PlayDecaySound()
    {
        PlayerSoundManager.PlaySound("ShrekSoundOne");
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    // Monobehaviour Functions

    void Start()
    {
        ShrekAnimator = GetComponent<Animator>();
        ShrekHealth = GetComponent<ShrekHealth>();
        PlayerSoundManager = GameObject.Find("Player").GetComponent<PlayerSoundManager>();

        SetState("Idle");
    }

    void Update()
    {
        HandleState();
    }
}
