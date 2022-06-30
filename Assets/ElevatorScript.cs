using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void ElevatorOpenDoor()
    {
        animator.SetTrigger("Open");
    }
}
