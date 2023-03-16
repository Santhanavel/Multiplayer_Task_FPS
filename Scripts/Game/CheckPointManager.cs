using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [SerializeField] Transform[] checkpoints;

    public static CheckPointManager instance;
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    
}
