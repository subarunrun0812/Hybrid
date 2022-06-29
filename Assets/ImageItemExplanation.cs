using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageItemExplanation : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject imageExplanationObj;
    private float displayTime = 2f;

    private void Start()
    {
        imageExplanationObj.SetActive(false);
    }
    //itemの説明
    public void ImageItem(Sprite itemImg, string explanation)//(画像、道具の名前)
    {
        imageExplanationObj.SetActive(true);
        img.sprite = itemImg;//アイテムの画像
        _text.text = explanation;//アイテム名のみ
        StartCoroutine("NoActiveCorutine");
    }
    IEnumerator NoActiveCorutine()
    {
        yield return new WaitForSeconds(displayTime);
        imageExplanationObj.SetActive(false);
    }
}
