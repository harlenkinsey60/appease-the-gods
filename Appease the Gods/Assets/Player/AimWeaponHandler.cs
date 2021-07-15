using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AimWeaponHandler : MonoBehaviour
{
    public GameObject Bazooka;
    public GameObject Missile;
    public GameObject HandBone;
    public GameObject ArmBone;

    public float LerpSpeed;
    public float T;
    public Vector3 OriginalBazookaPosition;
    public Quaternion OriginalBazookaRotation;
    float MissileLaunchTimer;
    

    // Monobehaviour Functions

    void Start()
    {
        Bazooka = Instantiate(Bazooka, HandBone.transform);
        LerpSpeed = 0.5f;
        T = 0.0f;
        OriginalBazookaPosition = Vector3.zero;
        OriginalBazookaRotation = new Quaternion(0,0,0,0);
        MissileLaunchTimer = 0.0f;
    }

    void Update()
    {
        // Handles Aiming Bazooka and Launching Missiles
        if(Input.GetKey(KeyCode.Mouse1))
        {
           AimWeapon();

            if(Input.GetKeyUp(KeyCode.Mouse0) && MissileLaunchTimer <= 0.0f)
            {
                LaunchMissile();
                MissileLaunchTimer = 3.0f;
            }

        }
        else 
        {
            StopAimingWeapon();
        }

        // Launch Cooldown

        if(MissileLaunchTimer > 0.0f)
        {
            MissileLaunchTimer -= Time.deltaTime;
        }

    }

    // Aiming Handler Methods

    public void AimWeapon()
    {
        if(T >= 1.0f && Bazooka.transform.localPosition != new Vector3(0f, -0.35f, 0.272f))
        {
            T = 0.0f;
        }

        if(T < 1.0f)
        {
            T += LerpSpeed * Time.deltaTime;
            Bazooka.transform.parent = Camera.main.transform;
            ArmBone.transform.localScale = Vector3.zero;
            Bazooka.transform.localPosition = Vector3.Lerp(Bazooka.transform.localPosition, new Vector3(0f, -0.35f, 0.272f), T);
            Bazooka.transform.localRotation = Quaternion.Lerp(Bazooka.transform.localRotation, Quaternion.Euler(new Vector3(-90,180,0)), T);
        }
    }

    public void StopAimingWeapon()
    {
        if(T >= 1.0f && Bazooka.transform.localPosition != OriginalBazookaPosition)
        {
            T = 0.0f;
        }

        if(T < 1.0f)
        {
            T += LerpSpeed * Time.deltaTime;
            ArmBone.transform.localScale = Vector3.one;
            Bazooka.transform.parent = HandBone.transform;
            Bazooka.transform.localPosition = Vector3.Lerp(Bazooka.transform.localPosition, OriginalBazookaPosition, T);
            Bazooka.transform.localRotation = Quaternion.Lerp(Bazooka.transform.localRotation, Quaternion.Euler(Vector3.zero), T);
        }   
    }

    // Handles Missile Instantiaion

    public void LaunchMissile()
    {
        GameObject LaunchedMissile = Instantiate(Missile, Camera.main.transform.position + (Camera.main.transform.forward * 2.0f), Camera.main.transform.rotation);
    }
}
