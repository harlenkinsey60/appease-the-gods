using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [HideInInspector]
    public string State;
    private Animator PlayerAnimator;

    // Getters and Setters

    public void SetState(string state)
    {
        State = state;
    }

    public string GetState()
    {
        return State;
    }

    // Handles the Player's State, Animation, Input, Movement, Inventory Interaction, and more 

    private void HandleState(){
        switch(State){
            case "Idle":
                
                // Handles Idle Mouse LockState

                Cursor.lockState = CursorLockMode.Locked;

                // Handles Idle State Input

                if(Input.GetKey(KeyCode.Mouse1))
                {
                    SetState("Aiming");
                }

                // Handles Idle State Animation

                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", false);

                LookAround();

                break;
            case "Walking":

                // Handles Idle State Input

                // Handles Idle State Animation

                break;
            case "Running":
                break;
            case "Jumping":
                break;
            case "Harvesting":
                break;
            case "Taking_Damage":
                break;
            case "Aiming":

                // Handles Aiming State Input

                if(!Input.GetKey(KeyCode.Mouse1))
                {
                    SetState("Idle");
                }

                LookAround();
                
                break;
            case "Dead":
                break;
        }
    }

    // Applies Mouse Movement to Player gameobject and camera

    [HideInInspector] public Vector3 Rotation = Vector3.zero;

    private void LookAround()
    {
        transform.Rotate(transform.up * Input.GetAxis("Mouse X") * 10f, Space.World);

        if(Rotation.x < 90.0f && Rotation.x > -90.0f)
        {
            Camera.main.transform.localEulerAngles = Rotation;
        }
        
        Rotation.x += Input.GetAxis("Mouse Y") * -5f;

        Debug.Log(Rotation.x.ToString());
    }


    // Monobehaviour Functions

    void Start()
    {
        State = "Idle";
        PlayerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleState();
    }
}
