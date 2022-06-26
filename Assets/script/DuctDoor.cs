using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class DuctDoor : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private GameObject driver;
    private bool OpenFlag;
    [SerializeField] private RequiredItemMessage requiredItemMessage;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void IsNearDoctDoor()
    {
        //一度開けたら開けっ放しにする
        //ドライバーが必要
        if (OpenFlag == true && driver.activeSelf == false)//ドアを開けるとき
        {
            this.transform.DOLocalRotate(new Vector3(0, -180, 0), 1.6f);
            OpenFlag = false;
            audioSource.PlayOneShot(openSE);
        }
        else//ドアが開けれないとき
        {
            requiredItemMessage.RequiredMessage("ねじ回しが必要");
        }
        // else//ドアを閉めるとき
        // {
        //     this.transform.DOLocalRotate(new Vector3(0, 0, 0), 1.0f);
        //     OpenFlag = true;
        //     audioSource.PlayOneShot(closeSE);
        // }
    }
}
