using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    Rigidbody MissileRigidbody;
    private float DecayTimer;
    public float MissileVelocity;
    public GameObject Explosion;
    GameObject Player;
     
    bool PlayerDamaged = false;

    // Monobehavior Functions

    void Start()
    {
        MissileRigidbody = GetComponent<Rigidbody>();
        DecayTimer = 10.0f;
        Player = GameObject.Find("Player");
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
        GetComponent<AudioSource>().Play();
    }

    void FixedUpdate()
    {
        MissileRigidbody.AddForce(transform.forward * MissileVelocity, ForceMode.Force);
    }

    void Update()
    {
        DecayTimer -= Time.deltaTime;

        if(DecayTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    // Callbacks

    public void OnCollisionEnter(Collision col)
    {
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

        // Handles Damaging the player

        float DistanceToPlayer = Vector3.Distance(Player.transform.position, transform.position);
        PlayerHUD PlayerHUD = Player.GetComponent<PlayerHUD>();

        // Fixes divide by 0 error

        if(DistanceToPlayer == 0.0f)  
        {
            DistanceToPlayer += 1.0f;
        }

        // Damages player based on distance

        if(DistanceToPlayer < 5.0f && PlayerDamaged == false)
        {
            PlayerHUD.SetHealth( PlayerHUD.GetHealth() - (20.0f / DistanceToPlayer) );
            PlayerDamaged = true;
        }
    }
}
