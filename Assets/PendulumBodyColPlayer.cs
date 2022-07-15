using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumBodyColPlayer : MonoBehaviour
{
    public bool player_f = false;
    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
            player_f = true;
    }
}
