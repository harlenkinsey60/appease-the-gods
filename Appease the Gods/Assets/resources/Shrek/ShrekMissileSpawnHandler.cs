using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrekMissileSpawnHandler : MonoBehaviour
{
    public GameObject Missile;
    ShrekState ShrekState;
    public float MissileSpawnCooldown = 7.0f;
    public int NumberOfMissileSpawns = 3;
    public float TimeBetweenSpawns = 0.7f;
    public bool IsSpawning = false;

    private IEnumerator SpawnCoroutine;
    
    
    // Handles Missile Spawning

    private IEnumerator SpawnMissiles()
    {
        MissileSpawnCooldown = 7.0f;
        IsSpawning = true;

        for(int i = 0; i < NumberOfMissileSpawns; i++) {

            GameObject SpawnedMissile = Instantiate(Missile, transform.up * 125f, Quaternion.identity);
            SpawnedMissile.transform.LookAt(GameObject.Find("Player").transform);

            yield return new WaitForSeconds(TimeBetweenSpawns);
        }

        IsSpawning = false;
    }

    // Monobehaviour Methods

    void Start()
    {
        ShrekState = GetComponent<ShrekState>();
    }

    void Update()
    {
        if(IsSpawning == false && MissileSpawnCooldown > 0.0f) 
        {
            MissileSpawnCooldown -= Time.deltaTime;

        } else if (IsSpawning == false && MissileSpawnCooldown <= 0.0f){
            SpawnCoroutine = SpawnMissiles();
            StartCoroutine(SpawnCoroutine);
        }
    }
}
