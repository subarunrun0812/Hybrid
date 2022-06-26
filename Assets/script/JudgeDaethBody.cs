using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDaethBody : MonoBehaviour
{
    [SerializeField] private DisconnectionBodyBag disconnectionBodyBag;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "NormalDoor")
        {
            disconnectionBodyBag.StartWhenTheDoorOpens();
        }
    }
}
