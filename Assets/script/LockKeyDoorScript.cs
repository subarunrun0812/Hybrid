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
    private float x;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        x = transform.localEulerAngles.x;
    }

    public void IsNearColorLockKeyDoor()
    {
        if (colorLockKey.lockflag == false)
        {
            if (OpenFlag == true)//ドアを開けるとき
            {
                this.transform.DOLocalRotate(new Vector3(x, -120, 0), 1.6f);
                OpenFlag = false;
                audioSource.PlayOneShot(openSE);

            }
            else//ドアを閉めるとき
            {
                CloseDoor();
            }
        }
        //鍵が閉まっているとき
        else
        {
            NotOpenAnim();
            audioSource.PlayOneShot(notOpenSE);
        }
    }
    public void CloseDoor()
    {
        this.transform.DOLocalRotate(new Vector3(x, 0, 0), 1.0f);
        OpenFlag = true;
        audioSource.PlayOneShot(closeSE);
    }
    private void NotOpenAnim()
    {
        DOTween.Sequence()
        .Append(this.transform.DOLocalRotate(new Vector3(x, 2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, 2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, 2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, 0, 0), 0.095f));
    }
}
