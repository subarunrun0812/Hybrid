using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportationScript : MonoBehaviour
{
    [SerializeField] private Transform teleportation_1;
    void OnTriggerEnter(Collider col)
    {
        if (col.transform.gameObject.tag == "Player")
        {
            col.transform.position = teleportation_1.position;
        }
    }
}
