using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TitleCreditsQuitButton : MonoBehaviour,
    IPointerDownHandler
{

    public System.Action onClickCallback;


    [SerializeField] private TiTleSceneManager titleSceneManager;

    void Start()
    {
    }
    //クリック時
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        titleSceneManager.QuitCreditsDisplay();//クレジットを表示
    }
}
