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

    // Monobehavior Functions

    void Start()
    {
        MissileRigidbody = GetComponent<Rigidbody>();
        DecayTimer = 10.0f;
        Player = GameObject.Find("Player");
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
    }
}
