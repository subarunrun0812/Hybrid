using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyDoor_Key : MonoBehaviour
{
    [SerializeField] private KeyDoor keyDoor;
    [SerializeField] private KeyCodeExplanation keyCodeExplanation;

    public void GetKey()//鍵を入手した時の処理
    {
        Debug.Log("GetKeyが呼ばれた");
        keyDoor.KeySE();//効果音を鳴らす
        keyCodeExplanation.MoveKeyCodeExplanation(false, 20, "", "鍵を入手した");
        this.gameObject.SetActive(false);
    }
}
