using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorridorHorrorTrap : MonoBehaviour
{
    [SerializeField] private GameObject voiceObj;//奇声を出すオブジェ
    [SerializeField] private AudioSource audioSource;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            audioSource.Play();
            this.gameObject.SetActive(false);
        }
    }
}
