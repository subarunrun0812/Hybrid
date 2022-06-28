using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class KeyCodeExplanation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI t_keycode;
    [SerializeField] private TextMeshProUGUI t_explanation;
    public GameObject shape;
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        this.transform.DOLocalMoveX(-200f, 0f);
    }

    //四角を表示するか,テキストフォントのサイズ、キーコード、説明
    public void MoveKeyCodeExplanation(bool active_f, int _fontsize, string keycode, string explanation)
    {
        shape.SetActive(active_f);
        //1文字の場合は40,3文字の場合は20
        t_keycode.fontSize = _fontsize;
        t_keycode.text = $"{keycode}";
        t_explanation.text = $"{explanation}";
        StartCoroutine("MoveExplanationCorutine");
    }
    IEnumerator MoveExplanationCorutine()
    {
        audioSource.Play();
        this.transform.DOLocalMoveX(0f, 1f)
        .SetEase(Ease.OutQuad);//Ease.OutQuadは最初が速く、徐々に緩やかになるイージング。

        yield return new WaitForSeconds(6f);

        this.transform.DOLocalMoveX(-200f, 1f)//画面外に移動する
        .SetEase(Ease.InQuad);//Ease.InQuadは最初が緩やかで、徐々に速くなるイージング。
    }
}
