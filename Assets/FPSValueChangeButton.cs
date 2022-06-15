using System.Collections;
using System.Collections.Generic;
using UnityEditor
using UnityEngine;
using UnityEngine.EventSystems;
public class FPSValueChangeButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private GameManager gameManager;
    public System.Action onClickCallback;

    //FPSの選択できる値
    public enum VALUE_TYPE
    {
        30,
        60
    }
    private VALUE_TYPE fps_value = VALUE_TYPE.30;
    //クリック時
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onClickCallback?.Invoke();
        if (fps_value == VALUE_TYPE.30)
            gameManager.ChangeFPSValue(30);
        if (fps_value == VALUE_TYPE.60)
            gameManager.ChangeFPSValue(60);
        fps_value = VALUE_TYPE;
    }
    //ポインターがオブジェクトに乗ったとき
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ポインタが乗ったとき");
    }
    //ポインターがオブジェクトから離れたとき
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("ポインタが離れたとき");
    }

}
