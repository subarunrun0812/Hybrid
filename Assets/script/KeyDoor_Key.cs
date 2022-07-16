using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyDoor_Key : MonoBehaviour
{
    [SerializeField] private KeyDoor keyDoor;

    //他のアイテムと同様のコード
    [SerializeField] private ImageItemExplanation imageItemExplanation;
    [SerializeField] private Sprite sprite;//鍵の透過画像を貼る
    [SerializeField] private string itemName_ja;
    [SerializeField] private string itemName_en;
    [SerializeField] private ChangeLanguage changeLanguage;
    //
    public void GetKey()//鍵を入手した時の処理
    {
        Debug.Log("GetKeyが呼ばれた");
        keyDoor.KeySE();//効果音を鳴らす
        if (changeLanguage.lannum == 0)
            imageItemExplanation.ImageItem(sprite, itemName_ja);
        else if (changeLanguage.lannum == 1)
            imageItemExplanation.ImageItem(sprite, itemName_en);

        this.gameObject.SetActive(false);
    }

}
