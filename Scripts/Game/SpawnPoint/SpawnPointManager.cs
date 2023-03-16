using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointManager : MonoBehaviour
{
    public static SpawnPointManager instance;

    Spawn_Point[] spawnPoint;


    private void Awake()
    {
        instance= this;
        spawnPoint = GetComponentsInChildren<Spawn_Point>();
    }
    public Transform SpawnPos()
    {
        int i = Random.Range(0, spawnPoint.Length);
        return spawnPoint[i].transform;
    }
}
