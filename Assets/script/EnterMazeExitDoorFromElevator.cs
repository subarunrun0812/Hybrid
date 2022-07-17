using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterMazeExitDoorFromElevator : MonoBehaviour
{
    [SerializeField] private MazeExitDoor mazeExitDoor;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            mazeExitDoor.CloseDoor();
            this.gameObject.SetActive(false);
        }
    }
}
