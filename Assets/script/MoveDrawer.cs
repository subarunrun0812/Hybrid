using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class MoveDrawer : MonoBehaviour
{
    [SerializeField] private Vector3 pos;
    private float pullTime = 0.6f;
    private float pushTime = 0.4f;
    private AudioSource audioSource;
    [Header("引き出しを引く時のSE")]
    [SerializeField] private AudioClip pullSE;
    [Header("戻す時のSE")]
    [SerializeField] private AudioClip pushSE;
    private int flag = 0;//0=引き出しを引いていない、1=引き出しを引いた（動かした)
    private Vector3 original_pos;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //初期位置のlocal座標のposを取得
        original_pos = gameObject.transform.localPosition;
        Debug.Log("初期位置は " + original_pos);
    }
    public void MoveDrawerFunction()
    {
        if (flag == 0)//引き出しを引く
        {
            this.gameObject.transform.DOLocalMove((pos), pullTime);
            audioSource.PlayOneShot(pullSE);
            flag = 1;
        }
        else//引き出しを戻す
        {
            this.gameObject.transform.DOLocalMove((original_pos), pushTime);
            audioSource.PlayOneShot(pushSE);
            flag = 0;
        }
    }
}
