using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOICE_CHAT_MANAGER : MonoBehaviour
{

    public static VOICE_CHAT_MANAGER instance;

    private void Awake()
    {
        if(instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance= this;
        }
    }
    private void Start()
    {
    }
}
