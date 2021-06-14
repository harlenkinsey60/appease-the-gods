using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string Type;
    private float Health;
    private Animator ResourceAnimator;

    // Getters and Setters

    public string GetType()
    {
        return Type;
    }

    public void SetHealth(float health)
    {
        Health = health;
    }

    public float GetHealth()
    {
        return Health;
    }

    private void Decay()
    {
        ResourceAnimator.SetBool("Decay", true);
    }

//Add unity event to call destroy
    public void Destroy()
    {
        Destroy(gameObject);
    }

    // Monobehaviour Methods

    void Start()
    {
        Debug.Log("Resource needs to implement animation event for Destroy()");
    }

}
