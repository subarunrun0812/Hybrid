using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveSpots : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private int spawnNumber;//spawnするスポットの場所
    [SerializeField] private GameObject[] spawn;

    void Awake()//リスポート地点を前回セーブしたところの続きから
    {
        spawnNumber = PlayerPrefs.GetInt("SpawnNumber", 0);//PlayerPrefs.GetInt(保存した時に使ったキーデフォルト値,データが保存されなかった時に表示する値)
        player.transform.position = spawn[spawnNumber].transform.position;
        Debug.Log("saveSpot: " + spawnNumber);
    }
    public void SaveSpot(int s_num)//特定のオブジェクトにいったら、自動的にセーブ
    {
        PlayerPrefs.SetInt("SpawnNumber", s_num);
        PlayerPrefs.Save();
    }
}
