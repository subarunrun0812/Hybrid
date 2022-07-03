using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class ElevatorHandle : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    private AudioSource audioSource;
    [SerializeField] Elevator_CabinScript elevator_CabinScript;
    [SerializeField] private AudioClip moveHandleSE;
    private float movetime = 0.8f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void MoveRotationHandle()//ハンドルを回したら、elevatorが降りる
    {
        StartCoroutine("WaiTimeCoturine");
        this.transform.DOLocalRotate((_rotation), movetime);
        audioSource.PlayOneShot(moveHandleSE);
        this.tag = "Untagged";
    }
    IEnumerator WaiTimeCoturine()
    {
        yield return new WaitForSeconds(2f);
        elevator_CabinScript.DownMoveElevator();

    }
}
