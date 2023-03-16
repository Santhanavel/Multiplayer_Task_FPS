using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Selection : MonoBehaviour
{
    public Button[] charButton;
    public GameObject maincam;

    public void LockChar()
    {
        Player_Manager.instance.CreateController();
        maincam.GetComponent<Camera>().enabled = false;

        gameObject.SetActive(false);

    }
    public void CharSelection(string val)
    {
        PlayerPrefs.SetString("CharName", val);
    }

   
   
}
