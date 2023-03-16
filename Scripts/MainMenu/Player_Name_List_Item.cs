using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Player_Name_List_Item : MonoBehaviourPunCallbacks
{
    [SerializeField] Text nameText;
    Player player;
    public void SetUp(Player _player)
    {
        player= _player;
        nameText.text = _player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player == otherPlayer) 
        {
         Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
