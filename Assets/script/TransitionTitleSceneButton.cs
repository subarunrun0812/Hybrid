using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TransitionTitleSceneButton : MonoBehaviour,
    IPointerDownHandler
{
    public System.Action onClickCallback;


    //クリック時
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("タイトルシーンに戻るbuttonが押された");
        onClickCallback?.Invoke();
        SceneManager.LoadScene("TitleScene");
    }
}
