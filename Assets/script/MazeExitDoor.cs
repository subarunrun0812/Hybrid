using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Playables;

[RequireComponent(typeof(AudioSource))]
public class MazeExitDoor : MonoBehaviour
{
    private AudioSource audioSource;
    public bool OpenFlag;
    [SerializeField] private AudioClip notOpenSE;
    [SerializeField] private GameObject timeline;//timelineexplosionをアタッチする
    [SerializeField] private PlayableDirector director;
    [SerializeField] private GameObject enemy;//普通のenemy
    [SerializeField] private FirstPersonLook firstPersonLook;
    [SerializeField] private GameObject _camera;
    [SerializeField] private SilentTimer silentTimer;
    [SerializeField] private GameManagerSE gameManagerSE;
    public bool fromElevator = true;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;

    void Start()
    {
        //doorのロックがされている時 false
        OpenFlag = false;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        timeline.SetActive(false);
    }
    public void ExitDoorOpneFlagTrue()//サイレンが呼ばれた時にtrueになる
    {
        OpenFlag = true;
    }
    public void IsNearMazeExitDoor()
    {
        if (OpenFlag == false)//ドアにロックがかかっているとき
        {
            if (fromElevator == true)
            {
                OpenDoor();
                fromElevator = false;
            }
            else
            {
                NotOpenAnim();
                audioSource.PlayOneShot(notOpenSE);
            }
        }
        else//ドアが開けれる時,//timelintのカットシーンに入る
        {
            StartTimeLine();
        }
    }
    public void CloseDoor()
    {
        this.transform.DOLocalRotate(new Vector3(0, 0, 0), 1.0f);
        audioSource.PlayOneShot(closeSE);
    }
    private void OpenDoor()
    {
        this.transform.DOLocalRotate(new Vector3(0, -120, 0), 1.6f);
        audioSource.PlayOneShot(openSE);

    }
    private void StartTimeLine()//timelineを再生する
    {
        //gameobject.tagを変更して、動的にドアを開けられないようにする
        this.tag = "Untagged";
        //timelineの終了を計算する
        director.paused += OnPlayableDirectorPaused;
        //timerを非表示にする  
        silentTimer.NoActiveTimer();
        silentTimer.enabled = false;//timerをリセットする
        _camera.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        //カメラを動かせないようにする
        firstPersonLook.enabled = false;
        timeline.SetActive(true);
        enemy.SetActive(false);
        gameManagerSE.ExitDoorStopChasingSE();//chasingSEを止める
    }
    public void EndTimeline()
    {
        Debug.Log("EndTimeLineが呼ばれた");
        firstPersonLook.enabled = true;
        gameManagerSE.ZeroHeartbeat();
    }
    private void OnPlayableDirectorPaused(PlayableDirector aDirector)
    {
        if (director == aDirector)
            Debug.Log("タイムラインが" + aDirector.name + "終了した");
    }

    private void NotOpenAnim()//鍵がかかっている時ドアをガチャガチャ
    {
        DOTween.Sequence()
        .Append(this.transform.DOLocalRotate(new Vector3(0, 2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f));
    }
}
