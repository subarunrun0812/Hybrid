using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrap : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if ((col.transform.gameObject.tag == "Player") || (col.transform.gameObject.tag == "BackRoomsDoor") || (col.transform.gameObject.tag == "NormalDoor"))
        {
            StartCoroutine("DestroyTrapCorutine");
        }
    }
    private IEnumerator DestroyTrapCorutine()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
