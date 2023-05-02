using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyDoor : MonoBehaviour
{

    [SerializeField] private GameObject[] keyDoor_d;
    [SerializeField] private GameObject[] keydoor_k;
    private bool OpenFlag;
    [SerializeField] private AudioSource audioSource;

    public void KeySE()//keyを入手した時の音
    {
        audioSource.Play();
    }
    public void KeyFlag(int num)//doorを開けるときkeyを持ってるか判断する
    {
        if (keydoor_k[num].activeSelf == false)//鍵持っている
        {
            KeyDoor_Door keyDoor_Door = keyDoor_d[num].GetComponent<KeyDoor_Door>();
            keyDoor_Door.OpenDoor();
        }
        else if (keydoor_k[num].activeSelf == true)//鍵を持っていない
        {
            KeyDoor_Door keyDoor_Door = keyDoor_d[num].GetComponent<KeyDoor_Door>();
            keyDoor_Door.NotOpenAnim();
        }
    }
}
