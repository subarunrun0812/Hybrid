using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemsUI : MonoBehaviour
{
    [SerializeField] private GameObject mapObj;
    [SerializeField] private GameObject mapUI;
    [SerializeField] private KeyCodeExplanation keyCodeExplanation;
    private int keyCount;
    private int countM = 0;//0 = 開けない,1 = 開ける,2 = 閉じる
    private void Start()
    {
        mapUI.SetActive(false);
    }
    public void BackRoomsKeys(int key)
    {
        keyCount++;
        if (keyCount == 3)
        {

        }
    }
    public void ActiveKey1UIFunction()
    {
    }
    public void NoActiveKey1UIFunction()
    {
    }
    public void MazeMapFunction()//mapを入手したときの処理
    {
        mapObj.SetActive(false);
        countM = 1;
        keyCodeExplanation.MoveKeyCodeExplanation(20, "", "マップを開く");
        GameObject[] mapArray = GameObject.FindGameObjectsWithTag("MazeMap");
        // mapを2度入手することを防ぐため
        for (int item = 0; item < mapArray.Length; item++)
        {
            mapArray[item].gameObject.tag = "Untagged";
            Debug.Log("MazeMapのタグが廃止された");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))//mを押したらmapが開く、再度押すと閉じる
        {
            if (countM == 1)//開く
            {
                mapUI.SetActive(true);
                // Time.timeScale = 0;
                countM = 2;
            }
            else if (countM == 2)//閉じる
            {
                mapUI.SetActive(false);
                // Time.timeScale = 1;
                countM = 1;

            }
        }
    }
}
