using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointTrigger : MonoBehaviour
{
    public int saveNumber;//inspectorで値。値はそのsceneの何番目のsaveポイントかで決める
    [SerializeField] private PlayerSaveSpots playerSaveSpots;
    void OnTriggerEnter(Collider col)
    {
        playerSaveSpots.SaveSpot(saveNumber);//saveポイントの数字を渡す。
        this.gameObject.SetActive(false);
    }
}
