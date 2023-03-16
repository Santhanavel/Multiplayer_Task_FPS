using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Player_Manager : MonoBehaviour
{
    PhotonView PV;
    GameObject controller;
    public static Player_Manager instance;
    public int deathcount;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        PV = GetComponent<PhotonView>();
        
    }
   

    public void CreateController()
    {

        string charname = PlayerPrefs.GetString("CharName");
        Transform spawnPos = SpawnPointManager.instance.SpawnPos();
        if (PV.IsMine)
        {
          controller = PhotonNetwork.Instantiate(Path.Combine("Photon Prefabs", charname), spawnPos.position, spawnPos.rotation, 0,new object[] {PV.ViewID});
          StartCoroutine(GameStartTime());
        }
    }
    IEnumerator GameStartTime()
    {
        yield return new WaitForSeconds(10);
        GameManager.instance.timerImg.SetActive(true);
        GameManager.instance.WaitForGameStart();
    }
    public void ReSpawnPlayer()
    {

        string charname = PlayerPrefs.GetString("CharName");
        Transform spawnPos = SpawnPointManager.instance.SpawnPos();
        if (PV.IsMine)
        {
            controller = PhotonNetwork.Instantiate(Path.Combine("Photon Prefabs", charname), spawnPos.position, spawnPos.rotation, 0, new object[] { PV.ViewID });
        }
    }
    public void Die()
    {
        PhotonNetwork.Destroy(controller);

        ReSpawnPlayer();
    }

    public void DeachCounts()
    {
        PV.RPC(nameof(DeathCount), PV.Owner);
    }
    [PunRPC]
    void DeathCount()
    {
        deathcount++;
        Hashtable hash = new Hashtable();
        hash.Add("Death", deathcount);
      //  PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}