using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class DeadBodyMove : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private NavMeshAgent deadBody;
    private AudioSource audioSource;
    private Rigidbody rigidbody;
    private Animator anim;
    private bool moveflag = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        deadBody = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        deadBody.isStopped = true;
    }

    public void StartMove()//追いかける
    {

        Debug.Log("死体が追いかける");
        deadBody.isStopped = false;
        deadBody.destination = player.transform.position;
        anim.SetTrigger("Walk");
        moveflag = true;
    }
    private void Update()
    {
        if (deadBody.remainingDistance <= 1 && moveflag == true)
        {
            rigidbody.isKinematic = false;
            deadBody.isStopped = true;
            deadBody.enabled = false;
            rigidbody.useGravity = true;
            anim.enabled = false;
        }
    }
    //playerに衝突した場合、追いかけるのを止め、rigidbodyをonにする
    void OnCollisionEnter(Collision col)
    {
        // if (col.gameObject.tag == "Player" && deadBody.isStopped == false)
        // {
        //     rigidbody.isKinematic = false;
        //     deadBody.isStopped = true;
        //     deadBody.enabled = false;
        //     rigidbody.useGravity = true;
        //     anim.enabled = false;
        // }
    }
}
