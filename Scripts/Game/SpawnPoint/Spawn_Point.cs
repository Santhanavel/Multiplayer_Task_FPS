using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Point : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpawnCapsual; 
    void Awake()
    {
        SpawnCapsual.SetActive(false);
    }

   
}
