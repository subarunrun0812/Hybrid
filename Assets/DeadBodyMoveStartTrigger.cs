using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBodyMoveStartTrigger : MonoBehaviour
{
    [SerializeField] private DeadBodyMove deadBodyMove;
    [SerializeField] private GameObject morgueBoxkey;
    void OnTriggerEnter(Collider col)
    {
        //鍵を入手&&playerに当たったら、死体を動かす
        if (col.gameObject.tag == "Player" && morgueBoxkey.activeSelf == false)
        {
            deadBodyMove.StartMove();
            this.gameObject.SetActive(false);
        }
    }
}
