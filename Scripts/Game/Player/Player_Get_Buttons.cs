using UnityEngine;
using UnityEngine.UI;
public class Player_Get_Buttons : MonoBehaviour
{
    [Header("UI BUTTONS")]
    public FixedJoystick joyStick;
    public FixedJoystick rotatejoyStick;
    public Button JumpButton;
    public GameObject scoreBoard;
    
    public static Player_Get_Buttons instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }


    }
}
