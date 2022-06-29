using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverItem : MonoBehaviour
{
    [SerializeField] private KeyCodeExplanation keyCodeExplanation;

    [SerializeField] private ImageItemExplanation imageItemExplanation;
    [SerializeField] private Sprite sprite;//透過画像を貼る
    [SerializeField] private string itemName;

    public void GetDriver()//鍵を入手した時の処理
    {
        imageItemExplanation.ImageItem(sprite, itemName);
        this.gameObject.SetActive(false);
    }
}
