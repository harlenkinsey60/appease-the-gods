using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    public float DecayTimer;

    void Start()
    {
        DecayTimer = 5.0f;
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
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
