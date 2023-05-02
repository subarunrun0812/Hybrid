using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerSaveSpots : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int spawnNumber;//spawnするスポットの場所
    [SerializeField] private GameObject[] spawn;
    [SerializeField] private FirstPersonLook firstPersonLook;
    [SerializeField] private FirstPersonMovement firstPersonMovement;
    void Awake()//リスポート地点を前回セーブしたところの続きから
    {
        spawnNumber = PlayerPrefs.GetInt("SpawnNumber", 0);//PlayerPrefs.GetInt(保存した時に使ったキーデフォルト値,データが保存されなかった時に表示する値)
        player.transform.position = spawn[spawnNumber].transform.position;
    }
    public void SaveSpot(int s_num)//特定のオブジェクトにいったら、自動的にセーブ
    {
        PlayerPrefs.SetInt("SpawnNumber", s_num);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        //デバッグ作業時はこれらのショートカットキーを使う
        // if (Input.GetKeyDown(KeyCode.Alpha0))
        // {
        //     PlayerPrefs.SetInt("SpawnNumber", 0);
        //     PlayerPrefs.Save();
        //     SceneManager.LoadScene("MainScene");
        // }
        // else if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     PlayerPrefs.SetInt("SpawnNumber", 1);
        //     PlayerPrefs.Save();
        //     SceneManager.LoadScene("MainScene");
        // }
        // else if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     PlayerPrefs.SetInt("SpawnNumber", 2);
        //     PlayerPrefs.Save();
        //     SceneManager.LoadScene("MainScene");
        // }
    }
}
