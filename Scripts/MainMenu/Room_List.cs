using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class Room_List : MonoBehaviour
{
    [SerializeField] Text roomNameText;
    public RoomInfo info;
    public void SetUp(RoomInfo _info)
    {
        info = _info;
        roomNameText.text = _info.Name;
    }
    public void OnClick()
    {
        MenuController.instance.JoinRoom(info);
    }
}
