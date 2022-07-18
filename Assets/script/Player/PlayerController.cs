using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private CharacterController m_CharacterController;
    void Start()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    //キャラクターコントローラーが移動中にコライダーに衝突した際
    {
        // if (hit.gameObject.tag == "AttackEnemyHand")
        // {
        //     Debug.Log("Playerがenemyに攻撃された");
        //     Time.timeScale = 0;
        // }
    }

}
