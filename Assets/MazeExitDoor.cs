using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using

[RequireComponent(typeof(AudioSource))]
public class MazeExitDoor : MonoBehaviour
{
    private AudioSource audioSource;
    public bool OpenFlag;
    [SerializeField] private AudioClip notOpenSE;

    void Start()
    {
        //doorのロックがされている時 false
        OpenFlag = false;
        audioSource = this.gameObject.GetComponent<AudioSource>();
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

        }
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
