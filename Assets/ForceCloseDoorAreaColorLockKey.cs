using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCloseDoorAreaColorLockKey : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private LockKeyDoorScript lockKeyDoorScript;//強制的に閉じるドア
    private void Start()
    {
        lockKeyDoorScript = door.GetComponent<LockKeyDoorScript>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            lockKeyDoorScript.CloseDoor();
            door.tag = "Untagged";
        }
        this.gameObject.SetActive(false);
    }
}
