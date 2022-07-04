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
    private string contents =
     "NewTexttetetdkfnvjoahfijhvajkfnvpo;avnasiljdfvhalkvjnasdofioauvnasjikldfhasfniovansidlfjhneaifjvoliasuhfnjklasdfh vaiolvhasdfjnasolfieuhjvniadfadsf";
    private void Start()
    {
        canvasGroup.alpha = 0f;
        _text.text = "";
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
        _text.DOText(contents, 15f).SetEase(Ease.Linear);
    }

}
