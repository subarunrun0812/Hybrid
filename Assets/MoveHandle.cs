using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class MoveHandle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    private AudioSource audioSource;
    [SerializeField] private AudioClip lowerSE;
    private float movetime = 0.8f;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void LowerHandle()
    {
        this.transform.DOLocalRotate((_rotation), movetime);
        audioSource.PlayOneShot(lowerSE);
        this.tag = "Untagged";
    }
}
