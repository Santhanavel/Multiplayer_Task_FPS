using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.Collections.Generic;

public class ScoreBoard_Manager : MonoBehaviourPunCallbacks
{
    [SerializeField] Transform continer;
    [SerializeField] GameObject scoreBoardItemPre;

    Dictionary<Player, ScoreBoardItem> scoreBoardItems = new Dictionary<Player, ScoreBoardItem>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            AddScoreBoardItem(player);
        }   
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreBoardItem(newPlayer);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreBoardItem(otherPlayer);
    }

    void AddScoreBoardItem(Player player)
    {
        ScoreBoardItem item =  Instantiate(scoreBoardItemPre,continer).GetComponent<ScoreBoardItem>();
        item.Initialize(player);
        scoreBoardItems[player] = item;
    }

    void RemoveScoreBoardItem(Player player)
    {
        Destroy(scoreBoardItems[player].gameObject);
        scoreBoardItems.Remove(player);
    }
}
