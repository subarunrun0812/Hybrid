using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator_CabinScript : MonoBehaviour
{
    [SerializeField] private Animator cabin_anim;
    [SerializeField] private AudioSource moveEleAudio;

    [SerializeField] private AudioClip cabin_OpenDoorSE;
    [SerializeField] private AudioClip cabin_CloseDoorSE;
    [SerializeField] private ElevatorScript elevatorScript;

    public void DownMoveElevator()
    {
        moveEleAudio.Play();
        StartCoroutine("DownMoveElevatorCorutine");
    }
    private float moveTime = 15f;
    // private float waitTime = 0f;
    IEnumerator DownMoveElevatorCorutine()
    {
        this.transform.DOLocalMoveY(-7.2f, moveTime);
        yield return new WaitForSeconds(moveTime);
        elevatorScript.ElevatorOpenDoor();
    }
    public void CabinOpenDoor()
    {
        cabin_anim.ResetTrigger("Close");
        cabin_anim.SetTrigger("Open");
    }
    public void CabinCloseDoor()
    {
        cabin_anim.SetTrigger("Close");
        cabin_anim.ResetTrigger("Open");
    }
}
