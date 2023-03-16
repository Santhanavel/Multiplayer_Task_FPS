using UnityEditor;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] Menu[] menus;

    private void Awake()
    {
        
            instance = this;
        
    }

    public void OpenMenu(string menuName)
    {
        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i]._MenuName == menuName)
            {
                menus[i].Open();
            }
            else if(menus[i].isOpen)
            {
                CloseMenu(menus[i]);
            }
        }


    }
    public void OpenMenu(Menu menu)
    {

        for (int i = 0; i < menus.Length; i++)
        {
            if (menus[i].isOpen)
            {
                CloseMenu(menus[i]);
            }
        }

        menu.Open();

    }
    public void CloseMenu(Menu menu)
    {
        menu.Close();

    }
}
