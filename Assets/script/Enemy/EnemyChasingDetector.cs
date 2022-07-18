using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasingDetector : MonoBehaviour
{
    //enemyがplayer追いかけるかどうか判断するためのbool値
    public bool chasingDec;
    void OnTriggerStay(Collider col)//範囲内に入っていたら追いかける
    {
        chasingDec = true;
    }
    void OnTriggerExit(Collider col)
    {
        chasingDec = false;
    }
}
