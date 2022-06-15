using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SilentTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI t_timerCount;
    //トータル制限時間
    private float totalTime;
    //制限時間（分）
    [SerializeField]
    private int minute;
    //制限時間（秒）
    [SerializeField]
    private float seconds;
    //前回Update時の秒数
    private float oldSeconds;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
    }

    void Update()
    {
        //制限時間が0秒以下なら何もしない
        if (totalTime <= 0f)
        {
            return;
        }
        //一旦トータルの制限時間を計測；
        totalTime = minute * 60 + seconds;
        totalTime -= Time.deltaTime;

        //再設定
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //タイマー表示用UIテキストに時間を表示する
        if ((int)seconds != (int)oldSeconds)
        {
            t_timerCount.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
        //制限時間以下になったらコンソールに『制限時間終了』という文字列を表示する
        if (totalTime <= 0f)
        {
            StartCoroutine("BigBangCorutine");
            Debug.Log("制限時間終了");
        }
    }
    private IEnumerator BigBangCorutine()
    {
        yield return new WaitForSeconds(3f);
        //大爆発のSEを流す
        audioSource.Play();
        //脱出出来なかった時の処理
    }
}
