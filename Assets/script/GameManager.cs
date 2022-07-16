using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup deathUI;//死んだ時の血の額縁と画面を暗くする
    [SerializeField] private CanvasGroup youdiedUI;
    [SerializeField] private GameObject retryButton;
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private GameObject player;
    [SerializeField] private FirstPersonLook firstPersonLook;

    private float deathWaitTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        deathUI.GetComponent<CanvasGroup>().alpha = 0;
        youdiedUI.GetComponent<CanvasGroup>().alpha = 0;
        retryButton.SetActive(false);
        // Use at most one pixel light for every object
        QualitySettings.pixelLightCount = 10;
        //settingMenuで変更した内容をロードする
        Application.targetFrameRate = PlayerPrefs.GetInt("fpsValue", 60);
        firstPersonLook.sensitivity = PlayerPrefs.GetFloat("mouseValue", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     SceneManager.LoadScene("ParkingUnderground");
        //     Time.timeScale = 1;
        // }
        // if (Input.GetKeyDown(KeyCode.T))
        // {
        //     PlayerPrefs.DeleteAll();
        // }
    }
    public void ChangeFPSValue(int fps)
    {
        Debug.Log("ChangeFPSValueが呼ばれた");
        //fpsを調整
        Application.targetFrameRate = fps;//macでテストした時重くなるため、FPSを下げる
    }

    public void PlayerDeath()//死んだ時のUIの処理
    {
        //透明度だけ上げる
        deathUI.DOFade(1f, deathWaitTime);
        StartCoroutine("YouDiedUICorutine");
    }
    private IEnumerator YouDiedUICorutine()//死んだ時のテキストを出すタイミングをずらす
    {
        yield return new WaitForSeconds(deathWaitTime / 3);
        youdiedUI.enabled = true;
        youdiedUI.DOFade(1f, deathWaitTime + deathWaitTime / 2);
        yield return new WaitForSeconds(deathWaitTime);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        retryButton.SetActive(true);
        Time.timeScale = 0;
    }

}