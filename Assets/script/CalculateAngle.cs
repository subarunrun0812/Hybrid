using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CalculateAngle : MonoBehaviour
{

    [SerializeField]
    private Transform baseObj;
    [SerializeField]
    private Transform fromObj;
    [SerializeField]
    private Transform toObj;
    [SerializeField]
    private GUIStyle gUIStyle;

    private float angle = 0f;

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        var rot = Quaternion.identity;
        var a = Vector3.zero;
        var b = Vector3.zero;

        // Vector3.Angle用の表示
        Handles.color = Color.black;
        Handles.DrawLine(baseObj.position, fromObj.position);
        Handles.DrawLine(baseObj.position, toObj.position);
        //fromObjの方向ベクトル
        a = fromObj.position - baseObj.position;
        //toObjの方向ベクトル
        b = toObj.position - baseObj.position;
        //fromObjからtoObjの角度
        angle = Vector3.SignedAngle(a, b, Vector3.up);
        Handles.Label(baseObj.position + Vector3.back * 0.5f, "<color=#ffffff>" + angle.ToString("F1") + "°" + "</color>", gUIStyle);
    }
#endif
    private void Update()
    {
        Debug.Log(angle);
    }
}