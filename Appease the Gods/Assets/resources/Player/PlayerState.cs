using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public string State {get; set;}

    void Start()
    {
        State = "Idle";
    }

    void Update()
    {
        HandleState();
    }

    private void HandleState(){
        switch(State){
            case "Idle":
                break;
            case "Walking":
                break;
            case "Running":
                break;
            case "Jumping":
                break;
            case "Harvesting":
                break;
            case "Taking_Damage":
                break;
            case "Dead":
                break;
        }
    }
}
