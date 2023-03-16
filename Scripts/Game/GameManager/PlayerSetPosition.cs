using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetPosition : MonoBehaviour
{
    private List<GameObject> players;
    private GameObject player;

    public static PlayerSetPosition instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
      
    }

    public void GetPlayers()
    {
        
    }
}
