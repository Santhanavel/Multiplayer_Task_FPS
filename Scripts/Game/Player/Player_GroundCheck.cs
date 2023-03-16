using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GroundCheck : MonoBehaviour
{
    Player_Controller _player;
    private void Awake()
    {
        _player = GetComponentInParent<Player_Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == _player.gameObject)
        {
            return;
        }
        _player.SetGroundedState(true);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            return;
        }
        _player.SetGroundedState(false);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == _player.gameObject)
        {
            return;
        }
        _player.SetGroundedState(true);
    }
}
