using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisconnectionBodyBag : MonoBehaviour
{
    [SerializeField] private CapsuleCollider col;
    [SerializeField] private GameObject supportPlane;//死体を上手く転がすためのもの
    private Rigidbody rigidbody;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
    }
    //ドアが開いたタイミングで呼ばれる
    public void StartWhenTheDoorOpens()
    {
        rigidbody.isKinematic = false;
        audioSource.Play();
        StartCoroutine("DiscconectionCorutine");
    }
    IEnumerator DiscconectionCorutine()
    {
        yield return new WaitForSeconds(2.2f);
        //接続を解除
        HingeJoint component = this.gameObject.GetComponent<HingeJoint>();
        Destroy(component);
        col.enabled = true;
        yield return new WaitForSeconds(1.5f);
        supportPlane.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartWhenTheDoorOpens();
        }
    }
}
