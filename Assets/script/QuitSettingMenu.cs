using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitSettingMenu : MonoBehaviour,
    IPointerDownHandler
// IPointerEnterHandler,
// IPointerExitHandler
{

    public System.Action onClickCallback;

    // [SerializeField] private GameObject before_img;
    // [SerializeField] private GameObject after_img;
    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private FirstPersonLook firstPersonLook;


    //クリック時
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onClickCallback?.Invoke();
        pauseMenu.QuitSettingMenu();
        //変更した内容をsaveする
        //mouse感度

    }
}
