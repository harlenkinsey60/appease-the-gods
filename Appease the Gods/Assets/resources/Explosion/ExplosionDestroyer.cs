using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour
{
    private float DecayTimer;

    void Start()
    {
        DecayTimer = 5.0f;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        DecayTimer -= Time.deltaTime;

        if(DecayTimer <= 0.0f)
        {
            Destroy(gameObject);
        }        
    }
}
