using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class MorgueBox_Door : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;
    private bool OpenFlag;
    private float x;
    private float y;
    private float z;

    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        x = transform.localEulerAngles.x;
        y = transform.localEulerAngles.y;
        z = transform.localEulerAngles.z;
    }

    public void IsNearDoor()
    {

        if (OpenFlag == true)//ドアを開けるとき
        {
            this.transform.DOLocalRotate(new Vector3(x, -90, z), 1.0f);
            OpenFlag = false;
            audioSource.PlayOneShot(openSE);

        }
        else//ドアを閉めるとき
        {
            this.transform.DOLocalRotate(new Vector3(x, 0, z), 0.6f);
            OpenFlag = true;
            audioSource.PlayOneShot(closeSE);
        }
    }

}
