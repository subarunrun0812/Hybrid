using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class ShelfDoor : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;
    private bool OpenFlag;
    private float opentime = 0.8f;
    private float closetime = 0.4f;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void IsNearNormalDoor()
    {

        if (OpenFlag == true)//ドアを開けるとき
        {
            this.transform.DOLocalRotate(new Vector3(0, -90, 0), opentime);
            OpenFlag = false;
            audioSource.PlayOneShot(openSE);

        }
        else//ドアを閉めるとき
        {
            this.transform.DOLocalRotate(new Vector3(0, 0, 0), closetime);
            OpenFlag = true;
            audioSource.PlayOneShot(closeSE);
        }
    }
}
