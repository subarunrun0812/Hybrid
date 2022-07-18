using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class TitleQuitSettingMenu : MonoBehaviour,
    IPointerDownHandler
{

    public System.Action onClickCallback;

    [SerializeField] private GameObject ui_;
    [SerializeField] private GameObject settingsMenu;
    //クリック時
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onClickCallback?.Invoke();
        ui_.SetActive(true);
        settingsMenu.SetActive(false);
        //変更した内容をsaveする
        //mouse感度

    }
}
