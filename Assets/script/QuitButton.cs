using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour,
    IPointerDownHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{

    public System.Action onClickCallback;

    [SerializeField] private GameObject before_img;
    [SerializeField] private GameObject after_img;
    [SerializeField] private PauseMenu pauseMenu;

    void Start()
    {
        before_img.SetActive(true);
        after_img.SetActive(false);
    }
    //クリック時
    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        onClickCallback?.Invoke();
        SceneManager.LoadScene("TitleScene");
    }
    //ポインターがオブジェクトに乗ったとき
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        before_img.SetActive(false);
        after_img.SetActive(true);
        Debug.Log("ポインタが乗ったとき");
    }
    //ポインターがオブジェクトから離れたとき
    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        before_img.SetActive(true);
        after_img.SetActive(false);
        Debug.Log("ポインタが離れたとき");

    }
}