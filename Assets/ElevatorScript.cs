using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// [RequireComponent(typeof(AudioSource))]
public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioSource cabinAudio;
    [Header("corpus = 外側,cabin = 内側")]
    [SerializeField] private AudioClip corpus_OpenDoorSE;
    [SerializeField] private AudioClip cabin_OpenDoorSE;
    [SerializeField] private AudioClip corpus_CloseDoorSE;
    [SerializeField] private AudioClip cabin_CloseDoorSE;
    [SerializeField] private AudioClip handleSE;
    private float moveTime = 8f;//Audioの再生が止まるとき
    [SerializeField] private Collider col;
    public void DownMoveElevator()
    {
        this.gameObject.transform.DOLocalMoveY(-5f, moveTime);
        _audioSource.Play();
    }
    private void Start()
    {
        // DownMoveElevator();
        // ElevatorOpenDoor();
    }
    public void ElevatorOpenDoor()
    {
        //外側の扉を初めに呼び出す
        Elevator_Handle();
        col.enabled = false;
        animator.SetTrigger("Open");
        animator.ResetTrigger("Close");
    }
    //animationEventから呼び出す
    //外側のドア
    public void Elevator_Handle()
    {
        _audioSource.PlayOneShot(handleSE);
    }
    public void Elevator_Corpus_OpenDoor()
    {
        _audioSource.PlayOneShot(corpus_OpenDoorSE);
    }
    //内側のドア
    public void Elevator_Cabin_OpenDoor()
    {
        cabinAudio.PlayOneShot(cabin_OpenDoorSE);
    }

    //ドアを閉じるとき
    public void Elevator_CloseDoor()
    {
        col.enabled = true;
        animator.ResetTrigger("Open");
        animator.SetTrigger("Close");
    }
    //外側の扉
    public void Elevator_Corpus_CloseDoor()
    {
        _audioSource.PlayOneShot(corpus_CloseDoorSE);
    }
    //内側のドア
    public void Elevator_Cabin_CloseDoor()
    {
        cabinAudio.PlayOneShot(cabin_CloseDoorSE);
    }
    private void Update()
    {
        Debug.Log(Time.deltaTime);
    }
}
