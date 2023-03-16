using System.Collections;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    public Animator timer_A;
    public AnimationClip timer;
    public GameObject timerImg;
    public GameObject starttext;

    public Transform[] GamePose;
    public bool gameStart = false;

    public static GameManager instance;

    private void Awake()
    {
        timerImg.SetActive(false);
        starttext.SetActive(false);
        if (instance == null)
        {
            instance = this;
            timerImg.SetActive(false);

        }
    }
    public void WaitForGameStart()
    {
        StartCoroutine(StartTime());
    }
    IEnumerator StartTime()
    {
        timerImg.SetActive(true);

        timer_A.Play("timer");
        yield return new WaitForSeconds(timer.length);
        timerImg.SetActive(false);
        starttext.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameStart = true;
        starttext.SetActive(false);

    }


}
