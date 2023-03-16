using UnityEngine;

public class Menu : MonoBehaviour
{
    public string _MenuName;
    public bool isOpen;
    public void Open()
    {
        isOpen= true;
        gameObject.SetActive(true);
    }
    public void Close()
    {
        isOpen= false;
        gameObject.SetActive(false);
    }
}
