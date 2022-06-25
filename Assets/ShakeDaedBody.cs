using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class ShakeDaedBody : MonoBehaviour
{
    private AudioSource audioSource;
    private float time = 1.5f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void DeadBodyShake()
    {
        transform.DOShakeRotation(time, 2f, 50, 50, false);
        audioSource.Play();
        //gameobject.tagを変更
        this.tag = "Untagged";
    }
}


