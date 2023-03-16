using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class Room_Manager : MonoBehaviourPunCallbacks
{
    public static Room_Manager Instance;

    private void Awake()
    {

        if(Instance)
        {
            Destroy(gameObject);
            return;
        }
       DontDestroyOnLoad(gameObject);
       Instance = this;
        
    }
    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene,LoadSceneMode loadSceneMode)
    {
        if(scene.buildIndex == 1)
        {
            PhotonNetwork.Instantiate(Path.Combine("Photon Prefabs", "----PLAYER MANAGER-----"), Vector3.zero, Quaternion.identity);
        }
    }
    public override void OnDisable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }
 
}
