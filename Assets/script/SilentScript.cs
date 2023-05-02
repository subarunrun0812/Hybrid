using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilentScript : MonoBehaviour
{
    [SerializeField] private AudioSource silentBGM;
    [SerializeField] private AudioSource timerBGM;
    [SerializeField] private SilentTimer silentTimer;
    [SerializeField] private SphereCollider enemyChasingDetector;
    private GameObject[] silentsArray;
    private GameObject[] leadLampArray;
    [SerializeField] private MazeExitDoor mazeExitDoor;

    private void Start()
    {
        silentsArray = GameObject.FindGameObjectsWithTag("Silent");
        leadLampArray = GameObject.FindGameObjectsWithTag("LeadLamp");
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
        enemyChasingDetector.radius = 30;//playerをずっと追いかけるようにする
        silentTimer.enabled = true;
        mazeExitDoor.ExitDoorOpneFlagTrue();//ExitDoorを開けれるようにする

        for (int i = 0; i < silentsArray.Length; i++)//rightのオンオフを切り替える
        {
            BlinkingLamp blinkingLamp = silentsArray[i].GetComponent<BlinkingLamp>();
            blinkingLamp.StartBlinkingLamp();
        }
        for (int i = 0; i < leadLampArray.Length; i++)//道しるべのランプを発光させる
        {
            LeadLampScript leadLampScript = leadLampArray[i].GetComponent<LeadLampScript>();
            leadLampScript.LeadLampFunction();
        }
    }
    public void TurnOffSilent()//爆弾が爆発したとき、ランプを非表示にす
    {
        for (int i = 0; i < leadLampArray.Length; i++)//すべてのサイレントを表示する
        {
            BlinkingLamp blinkingLamp = silentsArray[i].GetComponent<BlinkingLamp>();
            blinkingLamp.TurnOffBlinkingLamp();
        }
    }
}
