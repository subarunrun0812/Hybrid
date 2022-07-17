using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCloseDoorArea : MonoBehaviour
{
    [SerializeField] private ElevatorScript elevatorScript;
    [SerializeField] private Elevator_CabinScript elevator_CabinScript;
    [SerializeField] private Animator cabin_anim;

    void OnTriggerEnter(Collider col)
    {
        elevatorScript.Elevator_CloseDoor();
        elevator_CabinScript.CabinCloseDoor();
    }
}
