using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]

public class LockKeyDoorScript : MonoBehaviour
{
    [SerializeField] private ColorLockKey colorLockKey;
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;
    [SerializeField] private AudioClip notOpenSE;
    private bool OpenFlag;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void IsNearColorLockKeyDoor()
    {
        if (colorLockKey.doorflag == false)
        {
            if (OpenFlag == true)//ドアを開けるとき
            {
                this.transform.DOLocalRotate(new Vector3(-90, 0, -120), 1.6f);
                OpenFlag = false;
                audioSource.PlayOneShot(openSE);

            }
            else//ドアを閉めるとき
            {
                this.transform.DOLocalRotate(new Vector3(-90, 0, 0), 1.0f);
                OpenFlag = true;
                audioSource.PlayOneShot(closeSE);
            }
        }
        //鍵が閉まっているとき
        else
        {
            NotOpenAnim();
            audioSource.PlayOneShot(notOpenSE);
        }
    }
    private void NotOpenAnim()
    {
        DOTween.Sequence()
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 2), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 2), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 2), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.095f));
    }
}
