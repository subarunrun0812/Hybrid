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


        // //カメラを固定する
        // firstPersonLook.enabled = false;
        // //playerが移動出来ないようにする。
        // firstPersonMovement.playerMoveFlag = false;
        // //カメラをenemyの方に向ける
        // player.transform.LookAt(spawn[spawnNumber].transform.GetChild(0).gameObject.transform);
        // StartCoroutine("MoveCameraCorutine");


        // //スポーン時に向きを設定
        // //対象物と自分自身の座標からベクトルを算出
        // //子オブジェクトの順番で取得。最初が0で二番目が1となる。つまり↓は最初の子オブジェクト
        // GameObject child = spawn[spawnNumber].transform.GetChild(0).gameObject;
        // Vector3 vector3 = player.transform.position - child.transform.position;
        // // Quaternion(回転値)を取得
        // Quaternion quaternion = Quaternion.LookRotation(vector3);
        // // 算出した回転値をこのゲームオブジェクトのrotationに代入
        // // player.transform.LookAt(child.transform);
        // player.transform.rotation = spawn[spawnNumber].transform.rotation;

        // Debug.Log("quaternion" + quaternion);
        // Debug.Log(child.gameObject.name);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayerPrefs.SetInt("SpawnNumber", 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ParkingUnderground");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.SetInt("SpawnNumber", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ParkingUnderground");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.SetInt("SpawnNumber", 2);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ParkingUnderground");
        }
    }
    private IEnumerator MoveCameraCorutine()
    {
        yield return new WaitForSeconds(1f);
        // //カメラを固定する
        firstPersonLook.enabled = true;
        //playerが移動出来ないようにする。
        firstPersonMovement.playerMoveFlag = true;
    }
    public void SaveSpot(int s_num)//特定のオブジェクトにいったら、自動的にセーブ
    {
        PlayerPrefs.SetInt("SpawnNumber", s_num);
        PlayerPrefs.Save();
    }
}
