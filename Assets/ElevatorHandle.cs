using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class ElevatorHandle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    private AudioSource audioSource;
    [SerializeField] private AudioClip lowerSE;
    private float movetime = 0.8f;
    [SerializeField] private Material elevator_cabin;
    [SerializeField] private GameObject ele_light;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ele_light.SetActive(false);
    }
    public void LowerHandle()//ハンドルを回すとエレベーター
    {
        ele_light.SetActive(true);
        this.transform.DOLocalRotate((_rotation), movetime);
        audioSource.PlayOneShot(lowerSE);
        this.tag = "Untagged";
    }
}
