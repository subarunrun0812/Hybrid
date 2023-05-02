using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject menu;
    [SerializeField] private FirstPersonLook firstPersonLook;
    [SerializeField] private GameObject firstMenu;
    [SerializeField] private GameObject settingMenu;
    private int num = 0;
    void Start()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void MenuOn()
    {
        menu.SetActive(true);
        firstMenu.SetActive(true);
        settingMenu.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        firstPersonLook.enabled = false;
        Time.timeScale = 0;
    }

    public void MenuOff()
    {
        menu.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;//mouseのカーソルをロックする
        firstPersonLook.enabled = true;
        Time.timeScale = 1;
        Debug.Log("firstPersonLook:" + firstPersonLook.enabled);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
    public void SettingMenu()
    {
        firstMenu.SetActive(false);
        settingMenu.SetActive(true);
    }
    public void QuitSettingMenu()
    {
        firstMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//menu画面を表示
        {
            if (num == 0)//menu画面を開くとき
            {
                MenuOn();
                num = 1;
            }
            else//menu画面を閉じるとき
            {
                MenuOff();

                num = 0;
            }
        }
    }
}
