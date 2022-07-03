using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrivalElevator : MonoBehaviour
{
    [SerializeField] private Collider b1fcol;//B1Fのエレベーターのドア
    private void Start()
    {
        b1fcol.enabled = false;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            b1fcol.enabled = true;
        }
    }
}
