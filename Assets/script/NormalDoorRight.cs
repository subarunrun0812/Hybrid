using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class NormalDoorRight : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;
    private bool OpenFlag;
    private float x;
    private float z;
    void Start()
    {
        //doorが閉まっているときはtrue
        OpenFlag = true;
        audioSource = this.gameObject.GetComponent<AudioSource>();
        //これでインスペクター上に表示されているRotationのxの値が取得できます。
        x = transform.localEulerAngles.x;
        z = transform.localEulerAngles.z;
        Debug.LogError("x : " + x);
        Debug.LogError("z : " + z);

    }

    public void IsNearNormalDoor()
    {

        if (OpenFlag == true)//ドアを開けるとき
        {
            this.transform.DOLocalRotate(new Vector3(x, 120, z), 1.6f);
            OpenFlag = false;
            audioSource.PlayOneShot(openSE);
            Debug.LogError("Door_rを開けた");

        }
        else//ドアを閉めるとき
        {
            this.transform.DOLocalRotate(new Vector3(x, 0, z), 1.0f);
            OpenFlag = true;
            audioSource.PlayOneShot(closeSE);
        }
    }

}
