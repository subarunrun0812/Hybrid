using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator_CabinScript : MonoBehaviour
{
    [SerializeField] private Animator cabin_anim;
    [SerializeField] private AudioSource moveEleAudio;
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip cabin_OpenDoorSE;
    [SerializeField] private AudioClip cabin_CloseDoorSE;

    public void DownMoveElevator()
    {
        moveEleAudio.Play();
        StartCoroutine("DownMoveElevatorCorutine");
    }
    private float moveTime = 25f;
    // private float waitTime = 0f;
    IEnumerator DownMoveElevatorCorutine()
    {
        this.transform.DOLocalMoveY(-13.25f, moveTime);
        yield return new WaitForSeconds(moveTime - 4.5f);
        StartCoroutine("VolumeDown");
        yield return new WaitForSeconds(4.5f);
        Debug.Log("Elevatorがついた");
    }
    IEnumerator VolumeDown()
    {
        while (moveEleAudio.volume >= 0)
        {
            moveEleAudio.volume -= 0.05f;
            yield return new WaitForSeconds(0.1f);
            if (moveEleAudio.volume == 0)
            {
                moveEleAudio.Pause();
                break;
            }
        }

    }
    public void CabinOpenDoor()
    {
        cabin_anim.ResetTrigger("Close");
        cabin_anim.SetTrigger("Open");
        StartCoroutine("OpenDoorSECorutine");
    }
    IEnumerator OpenDoorSECorutine()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource.PlayOneShot(cabin_OpenDoorSE);
    }
    public void CabinCloseDoor()
    {
        cabin_anim.SetTrigger("Close");
        cabin_anim.ResetTrigger("Open");
    }
}
