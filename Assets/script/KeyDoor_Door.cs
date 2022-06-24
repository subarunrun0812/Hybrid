using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class KeyDoor_Door : MonoBehaviour
{
    [Header("door,key番号")]
    [SerializeField] private int num;
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;
    [SerializeField] private AudioClip notOpenSE;
    [SerializeField] private AudioClip getkeySE;
    private bool OpenFlag;
    [SerializeField] private KeyDoor keyDoor;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    public void IsNearDoor()//keydoorを選択したときに一番最初によばれるかんすう 
    {
        keyDoor.KeyFlag(num);
    }
    public void OpenDoor()
    {
        Debug.Log("OpenFlagが呼ばれた");
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
    public void NotOpenAnim()//鍵が閉まっているとき
    {
        audioSource.PlayOneShot(notOpenSE);
        DOTween.Sequence()
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 2), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 2), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 2), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(-90, 0, 0), 0.095f));
    }
}
