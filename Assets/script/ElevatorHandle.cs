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
    [SerializeField] private GameObject cube;//レバーを押したらエレベーターから出られないようにする。

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        cube.SetActive(false);
    }
    public void MoveRotationHandle()//ハンドルを回したら、elevatorが降りる
    {
        StartCoroutine("WaiTimeCoturine");
        this.transform.DOLocalRotate((_rotation), movetime);
        audioSource.PlayOneShot(moveHandleSE);
        this.tag = "Untagged";
        cube.SetActive(true);
    }
    IEnumerator WaiTimeCoturine()
    {
        yield return new WaitForSeconds(4f);
        elevator_CabinScript.DownMoveElevator();

    }
}
