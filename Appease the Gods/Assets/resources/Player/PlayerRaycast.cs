using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{

    private GameObject RecentlyHitGameObject;

    // if Raycast hits something then sets RecentlyHitGameObject to recently
    // hit gameobject and to null if it hits nothing

    public void SetObject(){
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0)); // shoots ray from center of screen

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            RecentlyHitGameObject = hit.collider.gameObject;
        }
        else {
            RecentlyHitGameObject = null;
        }

    }

    // returns RecentlyHitObject for use with other components

    public GameObject GetObject()
    {
        return RecentlyHitGameObject;
    }

}
