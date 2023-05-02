using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUnderTheBed : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Crouch crouch;//playerについているscript
    [SerializeField] private RayCamera rayCamera;
    [SerializeField] private Collider bedCollider;
    [SerializeField] private FirstPersonMovement firstPersonMovement;
    public bool underFlag = false;
    private float defaultHeadYLocalPosition = 1.4f;
    Transform myTransform;
    Vector3 beforeBedTransform;
    void Start()
    {
        myTransform = this.transform;
    }
    public void TheBedFunction()
    {
        if (underFlag == false)
        {
            underFlag = true;
            crouch.GetUnderTheBedTrue();
            UnderTheBed();
        }
        else//bedの下に潜り込んでいるとき
        {
            underFlag = false;
            crouch.GetUnderTheBedFalse();
            OutFromUnderTheBed();
        }
    }
    //ベッドの下に入るとき
    private void UnderTheBed()
    {
        bedCollider.enabled = false;
        beforeBedTransform = player.transform.position;

        //bedに潜り込むため、playerの身長を低くした
        crouch.headToLower.localPosition = new Vector3
        (crouch.headToLower.localPosition.x, crouch.crouchYHeadPosition = 0.2f, crouch.headToLower.localPosition.z);

        player.transform.position = myTransform.position;
        //playerが移動出来ないようにする。
        firstPersonMovement.playerMoveFlag = false;
    }
    //ベッドの下から出るとき
    private void OutFromUnderTheBed()
    {
        player.transform.position = beforeBedTransform;
        //bedに潜り込むため、playerの身長を低くした
        crouch.headToLower.localPosition = new Vector3
        (crouch.headToLower.localPosition.x, defaultHeadYLocalPosition, crouch.headToLower.localPosition.z);
        //playerが移動できる
        firstPersonMovement.playerMoveFlag = true;
        bedCollider.enabled = true;
    }
    void Update()
    {
        if (underFlag == true)//ベッドの下に潜り込んでいるときは常にEマークを表示する
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TheBedFunction();
            }
        }
    }
}