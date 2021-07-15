using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekHealth : MonoBehaviour
{
    private float Health;

    // Getters and Setters

    public float GetHealth()
    {
        return Health;
    }

    public void SetHealth(float health)
    {
        Health = health;
    }

    // Monobehaviour Functions

    void Start()
    {
        SetHealth(1000.0f);
    }
}
