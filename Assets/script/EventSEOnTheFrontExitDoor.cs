using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSEOnTheFrontExitDoor : MonoBehaviour
{
    [SerializeField] private GameManagerSE gameManagerSE;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameManagerSE.EventSEOnTheFrontExitDoor();
            this.gameObject.SetActive(false);
        }
    }
}
