using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{

    private GameObject RecentlyHitGameObject;
    private Vector3 HitPoint;

    // if Raycast hits something then sets RecentlyHitGameObject to recently
    // hit gameobject and to null if it hits nothing

    public void SetObject(){
        
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 0)); // shoots ray from center of screen

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            RecentlyHitGameObject = hit.collider.gameObject;
            HitPoint = hit.point;
        }
        else {
            RecentlyHitGameObject = null;
        }

    }

    public GameObject GetObject()
    {
        return RecentlyHitGameObject;
    }

    public Vector3 GetPoint()
    {
        return HitPoint;
    }

}
