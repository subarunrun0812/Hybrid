using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisconnectionBodyBag : MonoBehaviour
{
    [SerializeField] private CapsuleCollider col;
    [SerializeField] private GameObject supportPlane;//死体を上手く転がすため
    private Rigidbody rigidbody;
    [SerializeField] private AudioSource a_scream;
    [SerializeField] private AudioSource a_event;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
    //ドアが開いたタイミングで呼ばれる
    public void StartWhenTheDoorOpens()
    {
        rigidbody.isKinematic = false;
        StartCoroutine("DiscconectionCorutine");
    }
    IEnumerator DiscconectionCorutine()
    {
        a_scream.Play();
        yield return new WaitForSeconds(2.0f);
        a_event.Play();
        //接続を解除
        HingeJoint component = this.gameObject.GetComponent<HingeJoint>();
        Destroy(component);
        col.enabled = true;
        yield return new WaitForSeconds(1.5f);
        supportPlane.SetActive(false);
    }
}
