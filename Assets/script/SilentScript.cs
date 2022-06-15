using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentScript : MonoBehaviour
{
    [SerializeField] private AudioSource silentBGM;
    [SerializeField] private AudioSource timerBGM;
    [SerializeField] private SilentTimer silentTimer;
    private GameObject[] silentsArray;

    private void Start()
    {
        silentsArray = GameObject.FindGameObjectsWithTag("Silent");
        silentTimer.enabled = false;
    }
    public void PlaySilentBGM()
    {
        silentBGM.Play();
    }

    public void StopSilentBGM()
    {
        silentBGM.Stop();
    }
    public void StartSilent()//サイレンのライトと音楽を作動させる。爆発する前に逃げるシーン
    {
        Debug.Log("StartSilentが呼ばれた");
        PlaySilentBGM();
        timerBGM.Play();
        silentTimer.enabled = true;
        for (int i = 0; i < silentsArray.Length; i++)//すべてのサイレントをスタートさせる
        {
            BlinkingLamp blinkingLamp = silentsArray[i].GetComponent<BlinkingLamp>();
            blinkingLamp.StartBlinkingLamp();
            Debug.Log("i:" + i);
        }
    }
}
