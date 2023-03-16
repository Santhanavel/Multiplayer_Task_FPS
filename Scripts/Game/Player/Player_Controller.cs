using Photon.Pun;
using System.Collections;
using UnityEngine;
public class Player_Controller : MonoBehaviourPunCallbacks
{
    PhotonView PV;
    Player_Manager P_M;
    Rigidbody RB;
    Animator playerAnim;
    [SerializeField] GameObject camHolder;
    [SerializeField] float  walkSpeed,smoothtime,jumpForce;
    private Vector3 moveAmount;
    private Vector3 smoothMoveVelocity; 
    private float cameraPitch;
    bool isGrounded;
    

    private void Awake()    
    {
        RB= GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
        P_M = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<Player_Manager>();
        playerAnim= GetComponent<Animator>();
    }
    void Start()
    {

        if (photonView.IsMine)
        {
            Player_Get_Buttons.instance.JumpButton.onClick.AddListener(Jump);
        }
        else
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(RB);
        }
    }

    void Update()
    {
        if(GameManager.instance.gameStart)
        {
            if (!PV.IsMine)
            {
                return;
            }
            Walk();
            Look();
        }
        if (transform.position.y <= -15)
        {
            Die();
          //  Player_Manager.FindFirstObjectByType(typeof(Player_Manager));
        }

    }
    private void FixedUpdate()
    {
        if (!PV.IsMine )
        {
            return;
        }
        RB.MovePosition(RB.position + transform.TransformDirection(moveAmount)*Time.deltaTime);
    }

    private void Jump()
    {

        if (isGrounded && GameManager.instance.gameStart)
        {
            RB.AddForce(Vector3.up * jumpForce);
        }

    }
  
    private void Walk()
    {
        float moveX = Player_Get_Buttons.instance.joyStick.Horizontal;
        float moveZ = Player_Get_Buttons.instance.joyStick.Vertical;

        Vector3 moveDir = new Vector3(moveX, 0 ,moveZ).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * walkSpeed, ref smoothMoveVelocity,smoothtime);
        WalkAnim( moveX);
    }
    private void WalkAnim(float moveX)
    {

        if (moveX != 0)
        {
            playerAnim.SetBool("GunWalk", true);

        }
        else
        {
            playerAnim.SetBool("GunWalk", false);
        }
    }
    private void Look()
    {
        float moveX = Player_Get_Buttons.instance.rotatejoyStick.Horizontal;
        float moveY = Player_Get_Buttons.instance.rotatejoyStick.Vertical;

        // vertical (pitch) rotation
        cameraPitch = Mathf.Clamp((cameraPitch - moveY), -45f, 45f);
        camHolder.transform.localRotation = Quaternion.Euler(cameraPitch , 0, 0);

        // horizontal (yaw) rotation
        transform.Rotate(transform.up, moveX  );

    }

    public void SetGroundedState(bool state)
    {
        isGrounded = state;
    }
    void Die()
    {
        P_M.Die();
    }
}