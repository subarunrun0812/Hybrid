using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//強制的にしゃがみにするスクリプト
public class ForcedCrouchArea : MonoBehaviour
{
    [SerializeField] private Crouch crouch;
    void OnTriggerStay(Collider col)
    {
        crouch.forceCrouchVFlag(true);
    }
    //強制しゃがみareaから出た場合
    void OnTriggerExit(Collider col)
    {
        crouch.forceCrouchVFlag(false);
    }
}
