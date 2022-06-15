using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
// [RequireComponent(typeof(NavMeshObstacle))]
public class BackRoomsDoor : MonoBehaviour
{
    [SerializeField]
    private GUIStyle gUIStyle;
    private AudioSource audioSource;
    [SerializeField] private AudioClip openSE;
    [SerializeField] private AudioClip closeSE;
    private float openTime = 0.8f;
    private float closeTime = 0.4f;
    private float waitcloseTime = 2f;//ドアが開っきぱなしの時間
    private bool rotationFlag = true;//ドアを開けた後、数秒の間ドア本体が回転しないために制御
    [SerializeField]
    private Transform door;
    [SerializeField] private Transform fromObj;
    [SerializeField] private Transform player;
    private float y;//回転の向き
    private float angle = 0f;
    private float startDoor;
    Quaternion rot = Quaternion.identity;
    Vector3 a = Vector3.zero;
    Vector3 b = Vector3.zero;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        //インスペクターで設定されているドアの角度を取得
        startDoor = door.localEulerAngles.y;
        if ((45 <= startDoor && startDoor < 135) || (225 <= startDoor && startDoor < 315))
            fromObj.localPosition = new Vector3(door.localPosition.x, door.localPosition.y, door.localPosition.z - 5);
        else
            fromObj.localPosition = new Vector3(door.localPosition.x + 5, door.localPosition.y, door.localPosition.z);
    }

    private void Update()
    {
        // Vector3.Angle用の表示
        // Handles.color = Color.black;
        // Handles.DrawLine(door.position, fromObj.position);
        // Handles.DrawLine(door.position, player.position);
        //fromObjの方向ベクトル
        a = fromObj.position - door.position;
        //playerの方向ベクトル
        b = player.position - door.position;
        //fromObjからplayerの角度
        angle = Vector3.SignedAngle(a, b, Vector3.up);
        // Handles.Label(door.position + Vector3.back * 0.5f, "<color=#ffffff>" + angle.ToString("F1") + "°" + "</color>", gUIStyle);


        if (rotationFlag == true)
        {
            // 90 = angle = 負の値, 270 = angle = 正の値
            if ((45 <= startDoor && startDoor < 135) || (225 <= startDoor && startDoor < 315))
            {
                if (angle < 0)
                    door.rotation = Quaternion.Euler(0, 90f, 0);
                else
                    door.rotation = Quaternion.Euler(0, 270f, 0);
            }
            // 0 = angle = 負の値, 180 = angle = 正の値
            else
            {
                if (angle < 0)
                    door.rotation = Quaternion.Euler(0, 0f, 0);
                else
                    door.rotation = Quaternion.Euler(0, 180f, 0);
            }
        }
    }
    public void IsNearBackRoomsDoor()
    {
        Sequence seq = DOTween.Sequence();
        //ドアを開ける
        rotationFlag = false;
        audioSource.PlayOneShot(openSE);
        seq.Append(this.transform.DOLocalRotate(new Vector3(0, -120, 0), openTime))
        .AppendCallback(() =>
        {
            StartCoroutine("WaitCloseDoor");
        })
        //ドアを閉める
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), closeTime).SetDelay(waitcloseTime))
        .AppendCallback(() =>
        {
            //ドアが完全に閉まりきったら、ドア本体が回転することを許す
            rotationFlag = true;
        });
    }
    IEnumerator WaitCloseDoor()
    {
        yield return new WaitForSeconds(waitcloseTime);
        audioSource.PlayOneShot(closeSE);
    }
    public void MuteBackRooomsDoor()
    {
        Sequence seq = DOTween.Sequence();
        //ドアを開ける
        rotationFlag = false;
        seq.Append(this.transform.DOLocalRotate(new Vector3(0, -120, 0), openTime))
        .AppendCallback(() =>
        {
        })
        //ドアを閉める
        .Append(this.transform.DOLocalRotate(new Vector3(0, 0, 0), closeTime).SetDelay(waitcloseTime))
        .AppendCallback(() =>
        {
            //ドアが完全に閉まりきったら、ドア本体が回転することを許す
            rotationFlag = true;
        });
    }
}

