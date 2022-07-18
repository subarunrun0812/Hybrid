using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackDetector : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyController enemyCon;
    [SerializeField] private EnemySE enemySE;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameManagerSE gameManagerSE;

    //FirstPersonControllerを宣伝
    [SerializeField] private FirstPersonMovement firstPersonMovement;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //遷移する
            animator.SetTrigger("WalkAttack");
            //enemyの移動を止める
            enemyCon.EnemyAgentStopMove();
        }
    }
    public bool hitSE = false;//攻撃時にplayerが攻撃範囲内にいるか判断するため
    void OnTriggerStay(Collider col)
    {

        //攻撃モーション中 && playerが攻撃範囲内にいる時。playerを殺す処理
        if (enemyCon.attackFlag == true && col.gameObject.tag == "Player")
        {
            Debug.Log("Playerが死んだ");
            StartCoroutine("DeathPlayerCorutine");
            gameManager.PlayerDeath();
            hitSE = true;//hit中はtrueにする
            gameManagerSE.StopChasingSE();//BGMと鼓動おんを下げる
            firstPersonMovement.enabled = false;
        }
        else//playerがtrigger内にいない場合.殺さない
        {
            hitSE = false;
        }
    }
    private IEnumerator DeathPlayerCorutine()//死んだ時に時間が遅くなる
    {
        // //1~0.8まで減少
        for (float i = 1f; i >= 0.8f; i -= 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            Time.timeScale = i;
        }
    }

    void OnTriggerExit(Collider col)
    {
        enemyCon.EnemyAgentMove();
        // StartCoroutine("IncreaseCorutine");
    }

};