using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatingRoomHorrorTrap : MonoBehaviour
{
    [Header("同じ階層にあるドアをつける")]
    [SerializeField] private NotOpenDoorScript notOpenDoorScript;
    [SerializeField] private GameObject voiceObj;//奇声を出すオブジェ
    [SerializeField] private AudioSource audioSource;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            audioSource.Play();
            StartCoroutine("AnimCorutine");
        }
    }
    IEnumerator AnimCorutine()
    {
        yield return new WaitForSeconds(0.2f);
        notOpenDoorScript.NotOpenAnim();
        yield return new WaitForSeconds(0.095f * 7);
        notOpenDoorScript.NotOpenAnim();
        this.gameObject.SetActive(false);
    }
}
