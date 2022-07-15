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
    private string contents =
     "無事に、奴を仕留めれた。\nしかし、ここは一体なんの施設だっただろうか。\nなぜ、ここで人間とトナカイのハイブリッドを作っていたのだろうか。";
    private void Start()
    {
        canvasGroup.alpha = 0f;
        b_canvasGroup.alpha = 0f;
        _text.text = "";
        titlebutton.SetActive(false);
    }
    //TimeLineから呼び出す
    public void FadeInUI()
    {
        canvasGroup.DOFade(1f, 3f).OnComplete(() =>
        {
            EndStoryText();
        });
    }
    private void EndStoryText()
    {
        int contentsLength = contents.Length;
        _text.DOText(contents, t_time * contentsLength).SetEase(Ease.Linear);
        StartCoroutine("TransitionTitleScene");
    }
    private IEnumerator TransitionTitleScene()
    {
        int contentsLength = contents.Length;
        yield return new WaitForSeconds(t_time * contentsLength + 6f);
        titlebutton.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        b_canvasGroup.DOFade(1f, 2f);

    }

}
