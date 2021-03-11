using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string State;
    public float MovementSpeed;

    void Start()
    {
        SetState("Idle");
        MovementSpeed = 0.112f;
    }

    public void SetState(string NewState)
    {
        State = NewState;
        SendMessage("PlayerStateUpdated", NewState);
    }

}
