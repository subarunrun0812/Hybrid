using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ShakeDaedBody : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
            transform.DOShakeRotation(1f, 2f, 50, 50, false);
    }
}
