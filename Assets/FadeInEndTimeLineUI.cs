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
    private void Start()
    {
        canvasGroup.alpha = 0f;
        _text.DOFade(0f, 0f);
    }
    //TimeLineから呼び出す
    public void FadeInUI()
    {
        canvasGroup.DOFade(1f, 4f).OnComplete(() =>
        {
            EndStoryText();
        });
    }
    private void EndStoryText()
    {
        // _text.Dotext
    }

}
