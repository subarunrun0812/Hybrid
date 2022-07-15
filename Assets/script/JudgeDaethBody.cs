using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeDaethBody : MonoBehaviour
{
    [SerializeField] private DisconnectionBodyBag disconnectionBodyBag;
    [SerializeField] private PendulumBodyColPlayer pendulumBodyColPlayer;
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "NormalDoor" && pendulumBodyColPlayer.player_f == true)
        {
            disconnectionBodyBag.StartWhenTheDoorOpens();
            this.gameObject.SetActive(false);

        }
    }
}
