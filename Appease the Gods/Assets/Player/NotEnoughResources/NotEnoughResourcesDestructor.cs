using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotEnoughResourcesDestructor : MonoBehaviour
{
    private float TimeToDestruction = 3.0f;

    void Update()
    {
        if(TimeToDestruction > 0){
            TimeToDestruction -= Time.deltaTime;
        }
        else{
            Destroy(gameObject);
        }
    }
}
