using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class FPSValueChangeButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    [SerializeField] private GameManager gameManager;
    public System.Action onClickCallback;
    [SerializeField] private TextMeshProUGUI t_fps;

    //FPSの選択できる値
    public enum VALUE_TYPE
    {
        fps30,
        fps60
    }
    [SerializeField] private VALUE_TYPE fps_value = VALUE_TYPE.fps30;
    private void Start()
    {
        t_fps.text = $"{PlayerPrefs.GetInt("fpsValue", 60)}";
    }
    //クリック時
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onClickCallback?.Invoke();
        if (fps_value == VALUE_TYPE.fps30)
        {
            gameManager.ChangeFPSValue(30);
            t_fps.text = $"{30}";
            PlayerPrefs.SetInt("fpsValue", 30);
        }
        else if (fps_value == VALUE_TYPE.fps60)
        {
            gameManager.ChangeFPSValue(60);
            t_fps.text = $"{60}";
            PlayerPrefs.SetInt("fpsValue", 60);
        }
        PlayerPrefs.Save();

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
