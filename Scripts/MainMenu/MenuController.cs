using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;

public class MenuController : MonoBehaviourPunCallbacks
{
   
    [Header("INPUT FIELDS")]
    [SerializeField] InputField userName_Field;
    [SerializeField] InputField createRoom_Field;
    [SerializeField] InputField joinRoom_Field;
    [SerializeField] Text roomNameText;
    [SerializeField] Text errorText;
    [SerializeField] GameObject startButton;
    [Header("ROOM LIST")]
    [SerializeField] Transform listContant;
    [SerializeField] GameObject roomListItem;
    [Header("NAME LIST")]
    [SerializeField] Transform nameListContant;
    [SerializeField] GameObject nameListItem;

    public static MenuController instance;
    void Awake()
    {
        instance= this;
    }
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log("connected Mastter");
    }
    public override void OnJoinedLobby()
    {
        MenuManager.instance.OpenMenu("Panel_USER_NAME_GET");
        Debug.Log("connected lobby");

    }
   
    public void SetUserName()
    {
        PhotonNetwork.LocalPlayer.NickName = userName_Field.text;
    }

    public void CreateRoom()
    {
        if(string.IsNullOrEmpty(createRoom_Field.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(createRoom_Field.text, new Photon.Realtime.RoomOptions() { MaxPlayers = 4 }, null);
        MenuManager.instance.OpenMenu("Panel_LOADING");

    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Error" + message;
        MenuManager.instance.OpenMenu("Panel_ERROR");
    }
    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.instance.OpenMenu("Panel_LOADING");

       
    }
    public override void OnJoinedRoom()
    {
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
        MenuManager.instance.OpenMenu("Panel_JOINED_CREATED_ROOM");
        Player[] player = PhotonNetwork.PlayerList;
        foreach(Transform child in nameListContant)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < player.Count(); i++)
        {
            Instantiate(nameListItem, nameListContant).GetComponent<Player_Name_List_Item>().SetUp(player[i]);
        }
        startButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.instance.OpenMenu("Panel_LOADING");

    }
    public override void OnLeftRoom()
    {
        MenuManager.instance.OpenMenu("Panel_MAINTAB");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in listContant)
        {
            Destroy(trans.gameObject);
        }
        for(int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList) 
            {
                continue;
            }
            Instantiate(roomListItem, listContant).GetComponent<Room_List>().SetUp(roomList[i]);    
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(nameListItem, nameListContant).GetComponent<Player_Name_List_Item>().SetUp(newPlayer);
        
    }
    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        startButton.SetActive(PhotonNetwork.IsMasterClient);
    }
}
