using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycastHit : MonoBehaviour
{
    Ray ray;
    RaycastHit raycasthit;//hitしたオブジェクト情報

    private void Update()
    {
        ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        //レイキャスト(原点、飛ばす方向、衝突した情報、長さ)
        if (Physics.Raycast(ray, out raycasthit, 4f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raycasthit.distance, Color.yellow);
            if (raycasthit.transform.gameObject.tag == "BackRoomsDoor")
            {
                BackRoomsDoor backRoomsDoor = raycasthit.collider.GetComponent<BackRoomsDoor>();
                backRoomsDoor.MuteBackRooomsDoor();
                Debug.Log("EnemyがIsNearBackRoomsDoorを読んだ");
            }
        }
    }
}
