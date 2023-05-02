using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class FadeInEndTimeLineUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI _text;
    private float t_time = 0.12f;//１文字を表示する時間
    [SerializeField] private GameObject titlebutton;//titlesceneに戻るボタン
    [SerializeField] private CanvasGroup b_canvasGroup;
    [SerializeField] private GameObject fadeInUIEnd;
    [SerializeField] private ChangeLanguage changeLanguage;
    private string contents_ja =
     "あの爆破により、やつを仕留められた。\n一体やつはなんだったんだろうか。やつの素性を知るものはもう生きていない。\n\n\nこの後、私は外に繋がる出口を見つけ、無事に脱出することが出来た。";
    private string contents_en =
     "The bombing took him out.\nWhat in the world was he? There is no one left alive who knows his true identity.\n\n\nAfter that, I found a way out of the building and got out safely.";
    private void Start()
    {
        canvasGroup.alpha = 0f;
        b_canvasGroup.alpha = 0f;
        _text.text = "";
        titlebutton.SetActive(false);
        fadeInUIEnd.SetActive(false);
    }
    //TimeLineから呼び出す
    public void FadeInUI()
    {
        fadeInUIEnd.SetActive(true);
        canvasGroup.DOFade(1f, 3f).OnComplete(() =>
        {
            EndStoryText();
        });
    }
    //スクリプトから言語に応じてテキストを変更する。
    //Localization Tablesの設定したtextをanimationさせる方法が分からなかったため
    private int contentsLength;
    private void EndStoryText()
    {
        if (changeLanguage.lannum == 0)
        {
            contentsLength = contents_ja.Length;
            _text.DOText(contents_ja, t_time * contentsLength).SetEase(Ease.Linear);
        }
        else if (changeLanguage.lannum == 1)
        {
            contentsLength = contents_en.Length;
            _text.DOText(contents_en, t_time * contentsLength).SetEase(Ease.Linear);

        }
        StartCoroutine("TransitionTitleScene");
    }
    private IEnumerator TransitionTitleScene()
    {

        yield return new WaitForSeconds(t_time * contentsLength + 6f);
        titlebutton.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        b_canvasGroup.DOFade(1f, 2f);

    }

}
