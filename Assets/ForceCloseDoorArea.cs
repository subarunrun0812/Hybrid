using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceCloseDoorArea : MonoBehaviour
{
	[SerializeField] private GameObject door;
	private KeyDoor_Door keyDoor_Door;//強制的に閉じるドア
	private void Start()
	{
		keyDoor_Door = door.GetComponent<KeyDoor_Door>();
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			keyDoor_Door.CloseDoor();
			door.tag = "Untagged";
		}
        this.gameObject.SetActive(false);
    }
}
