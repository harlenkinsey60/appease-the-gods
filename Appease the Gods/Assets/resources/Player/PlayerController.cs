using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerData PlayerData;
    CharacterController CharacterController;
    Transform PlayerCamera;
    Animator PlayerAnimator;

    void Start()
    {
        PlayerData = GetComponent<PlayerData>();
        CharacterController = GetComponent<CharacterController>();
        PlayerCamera = Camera.main.transform;
        PlayerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        switch(PlayerData.State)
        {
            case "Idle":
                
                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", false);
                PlayerAnimator.SetBool("IsAiming", false);

                if(Cursor.lockState != CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
                
                if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    PlayerData.SetState("Walking");
                }

                if(Input.GetKeyDown(KeyCode.Tab))
                {
                    PlayerData.SetState("Upgrades");
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerData.SetState("Paused");
                }

                if(Input.GetMouseButton(0))
                {
                    PlayerData.SetState("Hitting");
                }

                break;

            case "Walking":

                PlayerAnimator.SetBool("IsWalking", true);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", false);
                PlayerAnimator.SetBool("IsAiming", false);

                if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
                {
                    PlayerData.SetState("Idle");
                }
                else if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKey(KeyCode.LeftShift))
                {
                    PlayerData.SetState("Running");
                }

                if(Input.GetKeyDown(KeyCode.Tab))
                {
                    PlayerData.SetState("Upgrades");
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerData.SetState("Paused");
                }

                break;

            case "Running":

                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", true);
                PlayerAnimator.SetBool("IsHitting", false);
                PlayerAnimator.SetBool("IsAiming", false);

                PlayerData.MovementSpeed = 0.224f;

                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    PlayerData.MovementSpeed = 0.114f;
                    PlayerData.SetState("Idle");
                }

                if(Input.GetKeyDown(KeyCode.Tab))
                {
                    PlayerData.SetState("Upgrades");
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerData.SetState("Paused");
                }

                break;

            case "Upgrades":

                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", false);
                PlayerAnimator.SetBool("IsAiming", false);

                if(Cursor.lockState != CursorLockMode.None)
                {
                    Cursor.lockState = CursorLockMode.None;
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerData.SetState("Idle");
                }

                break;

            case "Appease":

                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", false);
                PlayerAnimator.SetBool("IsAiming", false);

                if(Cursor.lockState != CursorLockMode.None)
                {
                    Cursor.lockState = CursorLockMode.None;
                }

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerData.SetState("Idle");
                }

                break;

            case "Hitting":

                PlayerAnimator.SetBool("IsWalking", false);
                PlayerAnimator.SetBool("IsRunning", false);
                PlayerAnimator.SetBool("IsHitting", true);
                PlayerAnimator.SetBool("IsAiming", false);

                if(!Input.GetMouseButton(0))
                {
                    PlayerData.SetState("Idle");
                }

                break;

            case "Paused":

                Cursor.lockState = CursorLockMode.None;

                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    PlayerData.SetState("Idle");
                }

                break;
        }
    
    }

    void HandleMovement()
    {
        switch (PlayerData.State)
        {
            case "Upgrades":
                break;

            case "Appease":
                break;

            case "Paused":
                break;
            
            case "Hitting":
                LookAround();
                break;

            default:
                CharacterController.Move(((transform.right * Input.GetAxis("Horizontal") * PlayerData.MovementSpeed) + (transform.forward * Input.GetAxis("Vertical") * PlayerData.MovementSpeed)));
                CharacterController.Move(Vector3.up * -9.81f);
                LookAround();
                break;
        }
    }

    [HideInInspector] public Vector3 CameraRotation = Vector3.zero;

    void LookAround()
    {
        transform.Rotate(transform.up * Input.GetAxis("Mouse X") * 10f, Space.World);

        if(CameraRotation.x < 90.0f && CameraRotation.x > -90.0f)
        {
            PlayerCamera.Rotate(Input.GetAxis("Mouse Y") * -10f, 0.0f, 0.0f, Space.Self);
        }
        else if(CameraRotation.x > 90.0f)
        {
            PlayerCamera.localEulerAngles = new Vector3(89.9f, PlayerCamera.localEulerAngles.y, PlayerCamera.localEulerAngles.z);
            CameraRotation.x = 89.9f;
        }
        else if(CameraRotation.x < -90.0f)
        {
            PlayerCamera.localEulerAngles = new Vector3(-89.9f, PlayerCamera.localEulerAngles.y, PlayerCamera.localEulerAngles.z);
            CameraRotation.x = -89.9f;
        }
        
        CameraRotation.x += Input.GetAxis("Mouse Y") * -10f;
    }

}
