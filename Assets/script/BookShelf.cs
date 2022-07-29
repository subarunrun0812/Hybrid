using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class BookShelf : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip moveSE;
    [SerializeField] private GameObject bookshelf;
    private float time = 2.0f;
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
        if (OpenFlag == true)//ドアを開けるとき
        {
            DOTween.Sequence()
            .Append(this.transform.DOLocalRotate(new Vector3(0, 0, -30f), 0.4f))
            .AppendCallback(() =>
            {
                audioSource.PlayOneShot(moveSE);
                OpenFlag = false;
                this.tag = "Untagged";
            })
            .Append(bookshelf.transform.DOLocalMoveZ(1.2f, time));
        }
    }
}
