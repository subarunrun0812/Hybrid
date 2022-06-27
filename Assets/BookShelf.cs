using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class BookShelf : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip moveSE;
    private float time = 1.0f;
    private bool OpenFlag;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }
    public void BookShelfMove()
    {
        //一度開けたら開けっ放しにする
        //ドライバーが必要
        if (OpenFlag == true)//ドアを開けるとき
        {
            this.transform.DOLocalMoveZ(1.2f, time);
            audioSource.PlayOneShot(moveSE);
            OpenFlag = false;
            this.tag = "Untagged";
        }
    }
}
