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
    private TextMeshProUGUI contentstext;
    private string contents;
    private void Start()
    {
        contentstext = GetComponent<TextMeshProUGUI>();
        contents = contentstext.text.ToString();
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
