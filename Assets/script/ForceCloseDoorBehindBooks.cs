using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCloseDoorBehindBooks : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private NormalDoor normalDoor;//強制的に閉じるドア
    private void Start()
    {
        normalDoor = door.GetComponent<NormalDoor>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            normalDoor.CloseDoor();
            door.tag = "Untagged";
        }
        this.gameObject.SetActive(false);

    }
}
