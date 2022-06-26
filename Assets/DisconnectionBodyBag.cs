using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisconnectionBodyBag : MonoBehaviour
{
    [SerializeField] private CapsuleCollider col;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //接続を解除
            HingeJoint component = this.gameObject.GetComponent<HingeJoint>();
            Destroy(component);

            col.enabled = true;

        }
    }
}
