using UnityEngine;
using UnityEngine.UI;
public class UI_Gun_Switch : MonoBehaviour
{
    public static UI_Gun_Switch instance;
    [Header("UI PISTOL AND GUN IMAGE")]
    public Image PistolImg;
    public Image AR_GunImg;
    [Header("BREAKER PISTOL AND GUN IMAGES")]
    public Sprite BREAKER_Pis;
    public Sprite BREAKER_GunImg;
    [Header("INSURGENT PISTOL AND GUN IMAGES")]
    public Sprite INSURGENT_Pis;
    public Sprite INSURGENT_GunImg;
    [Header("IRON_HEART PISTOL AND GUN IMAGES")]
    public Sprite IRON_HEART_Pis;
    public Sprite IRON_HEART_GunImg;
    [Header("IRONCLAD PISTOL AND GUN IMAGES")]
    public Sprite IRONCLAD_Pis;
    public Sprite IRONCLAD_GunImg;
    [Header("IRONSIDE PISTOL AND GUN IMAGES")]
    public Sprite IRONSIDE_Pis;
    public Sprite IRONSIDE_GunImg;
    [Header("SABOTAGE PISTOL AND GUN IMAGES")]
    public Sprite SABOTAGE_Pis;
    public Sprite SABOTAGE_GunImg;

    private int selectedChatVal;

    public SelectPlayerGun spg;
    public enum SelectPlayerGun
    {
        BREAKER,
        INSURGENT,
        IRON_HEART,
        IRONCLAD,
        IRONSIDE,
        SABOTAGE,
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public void Lock()
    {
        selectedChatVal = PlayerPrefs.GetInt("CharacterGunVal");
        Debug.Log("Get charVal" + selectedChatVal);
       // SetGunImageInUI(selectedChatVal);
    }

    void SetGunImageInUI(int val)
    {
        switch (val)
        {
            case 0: spg = SelectPlayerGun.BREAKER;
                PlayerPrefs.SetString("CharName", "BREAKER");
                PistolImg.sprite= BREAKER_Pis;
                AR_GunImg.sprite= BREAKER_GunImg;
                break;
            case 1:
                spg = SelectPlayerGun.INSURGENT;
                PlayerPrefs.SetString("CharName", "INSURGENT");

                PistolImg.sprite = INSURGENT_Pis;
                AR_GunImg.sprite = INSURGENT_GunImg;
                break;
            case 2:
                spg = SelectPlayerGun.IRON_HEART;
                PlayerPrefs.SetString("CharName", "IRON_HEART");

                PistolImg.sprite = IRON_HEART_Pis;
                AR_GunImg.sprite = IRON_HEART_GunImg;
                break;
            case 3:
                spg = SelectPlayerGun.IRONCLAD;
                PlayerPrefs.SetString("CharName", "IRONCLAD");

                PistolImg.sprite = IRONCLAD_Pis;
                AR_GunImg.sprite = IRONCLAD_GunImg;
                break;
            case 4:
                spg = SelectPlayerGun.IRONSIDE;
                PlayerPrefs.SetString("CharName", "IRONSIDE");

                PistolImg.sprite = IRONSIDE_Pis;
                AR_GunImg.sprite = IRONSIDE_GunImg;
                break;
            case 5:
                spg = SelectPlayerGun.SABOTAGE;
                PlayerPrefs.SetString("CharName", "SABOTAGE");

                PistolImg.sprite = SABOTAGE_Pis;
                AR_GunImg.sprite = SABOTAGE_GunImg;
                break;
        }
    }
}
