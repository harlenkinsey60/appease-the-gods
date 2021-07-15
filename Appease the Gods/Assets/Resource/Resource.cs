using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string Type;
    public float Health;
    private Animator ResourceAnimator;
    private AudioSource DecaySound;

    // Getters and Setters

    public string GetResourceType()
    {
        return Type;
    }

    public void SetHealth(float health)
    {
        Health = health;

        if(Health <= 0.0f)
        {
            Decay();
        }
    }

    public float GetHealth()
    {
        return Health;
    }

    private void Decay()
    {
        ResourceAnimator.SetBool("Decay", true);
        GetComponent<MeshCollider>().enabled = false;
    }
    
    public void PlayDecaySound()
    {
        DecaySound.Play();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    // Monobehaviour Methods

    void Start()
    {
        ResourceAnimator = GetComponent<Animator>();
        DecaySound = GetComponent<AudioSource>();
    }

}
