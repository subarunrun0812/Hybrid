using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverItem : MonoBehaviour
{
    [SerializeField] private KeyCodeExplanation keyCodeExplanation;

    public void GetDriver()//鍵を入手した時の処理
    {
        keyCodeExplanation.MoveKeyCodeExplanation(20, "tab", "ねじ回しを入手した");
        this.gameObject.SetActive(false);
    }
}
