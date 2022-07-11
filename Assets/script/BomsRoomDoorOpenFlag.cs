using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomsRoomDoorOpenFlag : MonoBehaviour
{
    [SerializeField] private SilentScript silentScript;
    [SerializeField] private GameObject eventSEObj;
    // [SerializeField] private caricatureTrap silentEnemy;
    // [SerializeField] private GameObject silentEnemyObj;

    // private void Start()
    // {
    //     silentEnemyObj.SetActive(false);
    // }
    void OnTriggerEnter(Collider col)
    {
        //爆弾が作動する
        if (col.gameObject.tag == "NormalDoor")
        {
            silentScript.StartSilent();
            Debug.Log("bamsRoomsDoorが開いた");
            eventSEObj.SetActive(false);
            //enemyを登場させる
            // silentEnemyObj.SetActive(true);
            // silentEnemy.EntryEnemy();
        }
    }
}
