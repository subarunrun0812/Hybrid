using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Playerのアイテム獲得時のSE、BGMを担当するscript
public class GameManagerSE : MonoBehaviour
{
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private AudioSource heartbeatAS;//鼓動音専用
    [SerializeField] private AudioSource audioSource2d;
    // [SerializeField] private AudioClip backHomeClip;//playerを見失ったとき
    [SerializeField] private AudioSource chasingBGM;

    void Start()
    {
        heartbeatAS.volume = 0f;
    }

    public void BackHomeSE()
    {
        audioSource2d.volume = 0.7f;
    }
    private bool exitdoor = false;
    public void ChasingSE()
    {
        if (exitdoor == false)
        {
            heartbeatAS.volume = 0.2f;
            heartbeatAS.pitch = 2.5f;//speed変更
                                     //追いかけられている時は鳴らす
            heartbeatAS.Play();

            //音をリセット
            chasingBGM.volume = 1.0f;
            chasingBGM.Play();
        }
    }
    public void ExitDoorStopChasingSE()//chasingSEが絶対にならないようにする
    {
        exitdoor = true;
        chasingBGM.Stop();
    }
    public void StopChasingSE()
    {
        //徐々に音量を下げる
        StartCoroutine("VolumeDown");
        StartCoroutine("ChasingBGMCorutine");
    }
    IEnumerator VolumeDown()
    {
        while (heartbeatAS.volume >= 0)
        {
            heartbeatAS.volume -= 0.01f;
            yield return new WaitForSeconds(0.1f);
            if (heartbeatAS.volume == 0)
            {
                heartbeatAS.Pause();
                break;
            }
        }
    }
    IEnumerator ChasingBGMCorutine()
    {
        while (chasingBGM.volume >= 0)
        {
            chasingBGM.volume -= 0.01f;
            yield return new WaitForSeconds(0.02f);
            if (chasingBGM.volume == 0)
            {
                chasingBGM.Pause();
                // audioSource2d.PlayOneShot(backHomeClip);
                break;
            }
        }
    }
    private void Update()
    {
        if (Time.timeScale == 0)//音をすべて消す
            AudioListener.volume = 0f;
        else//戻す
            AudioListener.volume = 1f;
    }

}
