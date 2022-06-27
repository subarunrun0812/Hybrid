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
    private bool OpenFlag;
    [SerializeField] private KeyDoor keyDoor;
    private float x;
    private float y;
    [Header("120度 or -120度")]
    [SerializeField] private int y_rotation;
    private float z;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        x = transform.localEulerAngles.x;
        y = transform.localEulerAngles.y;
        z = transform.localEulerAngles.z;
    }
    public void IsNearDoor()//keydoorを選択したときに一番最初によばれるかんすう 
    {
        keyDoor.KeyFlag(num);
    }
    public void OpenDoor()
    {
        Debug.Log("OpenDoorが呼ばれた");
        if (OpenFlag == true)//ドアを開けるとき
        {
            this.transform.DOLocalRotate(new Vector3(x, y_rotation, z), 1.6f);
            OpenFlag = false;
            audioSource.PlayOneShot(openSE);

        }
        else//ドアを閉めるとき
        {
            this.transform.DOLocalRotate(new Vector3(x, 0, z), 1.0f);
            OpenFlag = true;
            audioSource.PlayOneShot(closeSE);
        }
    }
    public void NotOpenAnim()//鍵が閉まっているとき
    {
        Debug.Log("NotOpenAnimが呼ばれた");
        audioSource.PlayOneShot(notOpenSE);
        DOTween.Sequence()
        .Append(this.transform.DOLocalRotate(new Vector3(x, y - 2, z), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, y, z), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, y - 2, z), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, y, z), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, y - 2, z), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(x, y, z), 0.095f));
    }
}
