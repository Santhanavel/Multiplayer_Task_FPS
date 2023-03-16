using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun;
using System;
using ExitGames.Client.Photon.StructWrapping;

public class ScoreBoardItem : MonoBehaviourPunCallbacks
{
    public Text userName;
    public Text time;
    public Text deathCount;

    Player player;
    public void Initialize(Player player)
    {
        userName.text = player.NickName;
        this.player = player;
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer,Hashtable changedProps)
    {
        if(targetPlayer == player)
        {
            if(changedProps.ContainsKey("DeathCount"))
            {
                updateStates();
            }
        }
    }

    private void updateStates()
    {
        if(player.CustomProperties.TryGetValue("Death",out object deaths))
        {
            deathCount.text = deaths.ToString();
        }
    }
}
