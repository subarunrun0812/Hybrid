using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[RequireComponent(typeof(AudioSource))]

public class parkToMuseumKey : MonoBehaviour
{
    public bool parkToMuseum_f;
    [SerializeField] private GameObject Key_parkTOMuseum;
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;
    [SerializeField] private AudioClip notOpenSE;
    [SerializeField] private AudioClip getItemSE;
    [SerializeField] private ItemsUI itemsUI;


    private bool OpenFlag;
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        //doorが閉まっているときはtrue
        OpenFlag = true;
        parkToMuseum_f = false;
    }
    //鍵を入手した時の処理
    public void parkTOMuseumKey()
    {
        parkToMuseum_f = true;
        Key_parkTOMuseum.SetActive(false);
        Debug.Log("鍵が消えた");
        //音の追加
        audioSource.PlayOneShot(getItemSE);
        itemsUI.ActiveKey1UIFunction();
    }
    public void door_parkToMuseumDoor()
    {
        if (parkToMuseum_f == true)
        {
            //ドアを開ける処理
            if (OpenFlag == true)//ドアを開けるとき
            {
                this.transform.DOLocalRotate(new Vector3(0, -120, 0), 1.6f);
                OpenFlag = false;
                audioSource.PlayOneShot(openSE);

            }
            else//ドアを閉めるとき
            {
                this.transform.DOLocalRotate(new Vector3(0, 0, 0), 1.0f);
                OpenFlag = true;
                audioSource.PlayOneShot(closeSE);
            }
            itemsUI.NoActiveKey1UIFunction();
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
        .Append(this.transform.DOLocalRotate(new Vector3(0, -2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, -2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, -2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f));

    }
}
