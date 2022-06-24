using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyDoor : MonoBehaviour
{

    [SerializeField] private GameObject[] keyDoor_d;
    [SerializeField] private GameObject[] keydoor_k;
    private bool OpenFlag;
    private AudioSource audioSource;
    public void KeySE()//keyを入手した時の音
    {
        audioSource.Play();
    }
    public void KeyFlag(int num)//doorを開けるときkeyを持ってるか判断する
    {
        Debug.Log("num = " + num);
        if (keydoor_k[num].activeSelf == false)//鍵が非表示になっていたら持っている判定になる
        {
            KeyDoor_Door keyDoor_Door = keyDoor_d[num].GetComponent<KeyDoor_Door>();
            keyDoor_Door.OpenDoor();
        }
        else if (keydoor_k[num].activeSelf == true)//鍵を持っていない時
        {
            KeyDoor_Door keyDoor_Door = keyDoor_d[num].GetComponent<KeyDoor_Door>();
            keyDoor_Door.NotOpenAnim();
        }
    }
}
