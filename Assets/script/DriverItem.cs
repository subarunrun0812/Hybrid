using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverItem : MonoBehaviour
{
    [SerializeField] private KeyCodeExplanation keyCodeExplanation;

    [SerializeField] private ImageItemExplanation imageItemExplanation;
    [SerializeField] private Sprite sprite;//透過画像を貼る
    [SerializeField] private string itemName_ja;
    [SerializeField] private string itemName_en;
    [SerializeField] private ChangeLanguage changeLanguage;
    public void GetDriver()//鍵を入手した時の処理
    {
        if (changeLanguage.lannum == 0)
            imageItemExplanation.ImageItem(sprite, itemName_ja);
            
        else if (changeLanguage.lannum == 1)
            imageItemExplanation.ImageItem(sprite, itemName_en);
        this.gameObject.SetActive(false);
    }
}
