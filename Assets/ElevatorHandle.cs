using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class ElevatorHandle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    private AudioSource audioSource;
    [SerializeField] private AudioClip moveHandleSE;
    private float movetime = 0.8f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void MoveRotationHandle()//ハンドルを回す
    {
        this.transform.DOLocalRotate((_rotation), movetime);
        audioSource.PlayOneShot(moveHandleSE);
        this.tag = "Untagged";
    }
}
