using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour,
    IPointerDownHandler
{

    public System.Action onClickCallback;


    //クリック時
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onClickCallback?.Invoke();
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }
}