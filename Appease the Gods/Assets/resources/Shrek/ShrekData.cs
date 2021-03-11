using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekData : MonoBehaviour
{
    public string State;

    void Start()
    {
        SetState("Dancing"); 
    }

    void Update()
    {
        
    }

    public void SetState(string state)
    {
        State = state;
        SendMessage("ShrekStateUpdated", state);
    }
}
