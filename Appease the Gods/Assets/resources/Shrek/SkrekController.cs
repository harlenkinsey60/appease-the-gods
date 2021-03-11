using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkrekController : MonoBehaviour
{

    ShrekData ShrekData;
    Animator ShrekAnimator;

    void Start()
    {
        ShrekData = GetComponent<ShrekData>();
        ShrekAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    void HandleStates()
    {
        switch(ShrekData.State)
        {
            case "Dancing":
                ShrekAnimator.SetBool("IsDancing", true);
                ShrekAnimator.SetBool("IsTPosing", false);
                break;
        }
    }
}
