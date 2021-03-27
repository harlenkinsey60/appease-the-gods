using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    GameObject Shrek;

    void Start()
    {
        Shrek = GameObject.Find("Shrek");
    }

    void Update()
    {
        transform.RotateAround(Shrek.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
