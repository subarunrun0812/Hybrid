using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// [RequireComponent(typeof(AudioSource))]
public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    private float moveTime = 8f;//Audioの再生が止まるとき
    private void Start()
    {
        // DownMoveElevator();
    }

    public void ElevatorOpenDoor()
    {
        animator.SetTrigger("Open");
    }
    public void DownMoveElevator()
    {
        this.gameObject.transform.DOLocalMoveY(-5f, moveTime);
        audioSource.Play();
    }
    private void Update()
    {
        Debug.Log(Time.deltaTime);
    }
}
