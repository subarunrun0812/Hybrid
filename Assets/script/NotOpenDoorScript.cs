using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class NotOpenDoorScript : MonoBehaviour
{
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip notOpenSE;
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    public void IsNearNotOpenDoor()
    {
        NotOpenAnim();
    }
    public void NotOpenAnim()
    {
        // animator.SetTrigger("NotOpen");
        audioSource.PlayOneShot(notOpenSE);
        DOTween.Sequence()
        .Append(this.transform.DOLocalRotate(new Vector3(0, -2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, -2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, -2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, -2, 0), 0.095f))
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), 0.095f));
    }
}
