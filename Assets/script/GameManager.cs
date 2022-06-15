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
    [SerializeField] private EnemyController enemyController;
    [SerializeField] private GameObject player;

    private float deathWaitTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        deathUI.GetComponent<CanvasGroup>().alpha = 0;
        youdiedUI.GetComponent<CanvasGroup>().alpha = 0;
        // Use at most one pixel light for every object
        QualitySettings.pixelLightCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //fpsを調整
        Application.targetFrameRate = 60;

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("ParkingUnderground");
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            PlayerPrefs.DeleteAll();
        }
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
        Time.timeScale = 0;
    }

}