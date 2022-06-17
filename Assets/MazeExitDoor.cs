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



    void Start()
    {
        //doorのロックがされている時 false
        OpenFlag = false;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        timeline.SetActive(false);

        //timelineの終了を計算する
        director.paused += OnPlayableDirectorPaused;
    }
    public void ExitDoorOpneFlagTrue()//サイレンが呼ばれた時にtrueになる
    {
        OpenFlag = true;
    }
    public void IsNearMazeExitDoor()
    {
        if (OpenFlag == false)//ドアにロックがかかっているとき
        {
            NotOpenAnim();
            audioSource.PlayOneShot(notOpenSE);
        }
        else//ドアが開けれる時,//timelintのカットシーンに入る
        {
            StartTimeLine();
        }
    }
    private void StartTimeLine()//timelineを再生する
    {
        //カメラを動かせないようにする
        firstPersonLook.enabled = false;
        timeline.SetActive(true);
        enemy.SetActive(false);
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
