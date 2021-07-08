using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [HideInInspector]
    public string State;
    private Animator PlayerAnimator;
    public GameObject GatherParticleSystem;
    PlayerPauseUI PlayerPauseUI;
    PlayerInventory PlayerInventory;
    CharacterController CharacterController;

    float MovementSpeed = 0.114f;

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

                Cursor.lockState = CursorLockMode.Locked;

                // Handles Idle State Input
                
                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    SetState("Walking");
                }

                if(Input.GetKeyDown(KeyCode.Tab))
                {
                    SetState("Inventory");
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SetState("Paused");
                }

                if(Input.GetMouseButton(0) && (PlayerInventory.GetAxeType() > -1 || PlayerInventory.GetPickaxeType() > -1) && (PlayerInventory.GetAxeDurability() > 0 || PlayerInventory.GetPickaxeDurability() > 0))
                {
                   SetState("Harvesting");
                }

                if(Input.GetKey(KeyCode.Mouse1) && PlayerInventory.GetSelected() == 2)
                {
                    SetState("Aiming");
                }
                
                QuerySelected(); // Updates selected item based on input

                // Handles Idle State Animation

                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", false);

                LookAround();

                break;

            case "Walking":

                Cursor.lockState = CursorLockMode.Locked;

                MovementSpeed = 0.114f;

                // Handles Walking State Input

                if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    SetState("Idle");
                }
                else if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
                {
                    SetState("Running");
                }

                if(Input.GetKeyDown(KeyCode.Tab))
                {
                    SetState("Inventory");
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SetState("Paused");
                }

                QuerySelected(); // Updates selected item based on input

                // Handles Walking State Animation

                PlayerAnimator.SetBool("IsWalking", true);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", false);

                LookAround();

                break;

            case "Running":

                Cursor.lockState = CursorLockMode.Locked;

                MovementSpeed = 0.224f;

                // Handles Running State Input

                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    SetState("Idle");
                }

                if(Input.GetKeyDown(KeyCode.Tab))
                {
                    SetState("Inventory");
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SetState("Paused");
                }

                QuerySelected(); // Updates selected item based on input

                // Handles Running State Animation

                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", true);
                PlayerAnimator.SetBool("IsHitting", false);
                
                LookAround();

                break;

            case "Harvesting":

                Cursor.lockState = CursorLockMode.Locked;

                // Handles Harvesting State Input

                if(!Input.GetMouseButton(0))
                {
                    SetState("Idle");
                }

                QuerySelected(); // Updates selected item based on input

                // Handles Harvesting State Animation

                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", true);

                break;

            case "Taking_Damage":
                break;

            case "Aiming":

                Cursor.lockState = CursorLockMode.Locked;
                
                MovementSpeed = 0.057f;

                // Handles Aiming State Input

                if(!Input.GetKey(KeyCode.Mouse1))
                {
                    SetState("Idle");
                }

                QuerySelected(); // Updates selected item based on input

                LookAround();
                
                break;

            case "Inventory":

                Cursor.lockState = CursorLockMode.None;

                if(PlayerInventory.GetHideUI() == true)
                {
                    PlayerInventory.SetHideUI(false);
                } 

                if(Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerInventory.SetHideUI(true);
                    SetState("Idle");
                }

                break;
            
            case "Paused":

                Cursor.lockState = CursorLockMode.None;

                if(PlayerPauseUI.GetHideUI() == true)
                {
                    PlayerPauseUI.SetHideUI(false);
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerPauseUI.SetHideUI(true);
                    SetState("Idle");
                }

                break;

            case "Dead":

                Cursor.lockState = CursorLockMode.None;

                break;
        }
    }

    void HandleMovement()
    {
        switch(State)
        {
            case "Idle":
            
            case "Walking":
            
            case "Running":

                Movement();

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    Jump();
                }

                break;
        }
    }

    // Moves player

    void Movement()
    {
        CharacterController.Move(((transform.right * Input.GetAxis("Horizontal") * MovementSpeed) + (transform.forward * Input.GetAxis("Vertical") * MovementSpeed)));
        CharacterController.Move(Vector3.up * -9.81f * Time.deltaTime);
    }

    void Jump()
    {
        if(CharacterController.isGrounded)
        {
            CharacterController.Move(Vector3.up * 2f);
        }
    }

    // Updates Selected in PlayerInventory based on input

    public void QuerySelected()
    {
        if(Input.mouseScrollDelta.y != 0f)
        {
            if(PlayerInventory.GetSelected() == 0)
            {
                PlayerInventory.SetSelected(1);
            } else {
                PlayerInventory.SetSelected(0);
            }
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
    }

    // Handles Respawing Player

    public void Respawn()
    {
        // Generates a random point in a unit circle with a radius of 180

        Vector2 GeneratedRandom = Random.insideUnitCircle * 180;
        
        // Checks if point is far enough away from center podium and if not calls on itself

        if(Vector2.Distance(Vector2.zero, GeneratedRandom) < 60.0f)
        {
            Respawn();
        }

        // Sets player position for respawn (disables then enables character controller because it hijacks control of player's position)

        CharacterController.enabled = false;
        transform.position = new Vector3(GeneratedRandom.x, 10.0f, GeneratedRandom.y);
        CharacterController.enabled = true;

        // Resets player's inventory

        PlayerInventory.SetWoodCount(0);
        PlayerInventory.SetStoneCount(0);
        PlayerInventory.SetMetalCount(0);

        // Destroys death screen object and changes state

        Destroy(GameObject.Find("DeathScreen"));
        SetState("Idle");
    }


    // Monobehaviour Functions

    void Start()
    {
        State = "Idle";
        PlayerAnimator = GetComponent<Animator>();
        PlayerInventory = GetComponent<PlayerInventory>();
        CharacterController = GetComponent<CharacterController>();
        PlayerPauseUI = GetComponent<PlayerPauseUI>();
    }

    void Update()
    {
        HandleState();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }
}
