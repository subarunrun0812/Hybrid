using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public bool attackFlag = false;//攻撃animation中かどうか判断するため
    [SerializeField] private EnemyChasingDetector enemyChaDet;
    [SerializeField] private EnemySE enemySE;
    [SerializeField] private GameManagerSE gameManaSE;
    private GameObject[] fukuroPics;//fukuroの絵を入れる
    private NavMeshAgent _enemy;
    public bool backHomeSE_f;//敵を見失った時に一回だけ音を鳴らす
    private bool chasingSE_f = true;
    [SerializeField] private FirstPersonLook firstPersonLook;
    [SerializeField] private FirstPersonMovement firstPersonMovement;

    void Start()
    {
        _enemy = GetComponent<NavMeshAgent>();
        fukuroPics = GameObject.FindGameObjectsWithTag("FukuroPic");
    }
    public void EnemyAgentMove()//enemyが壁から登場しanimationをした後に追いかける
    {
        //追いかける範囲内にプレイヤーがいたら追いかける
        if (enemyChaDet.chasingDec == true)
        {
            _enemy.isStopped = false;
            _enemy.destination = player.transform.position;
            //音関係
            backHomeSE_f = true;
            if (chasingSE_f == true)
            {
                gameManaSE.ChasingSE();
                chasingSE_f = false;
            }
        }
        else//一番近くの絵を目的地にして、戻る
        {
            GameObject nearestPic = null;//一番近い絵を格納する
            float minDis = 1000f;//一番近い距離を格納する
            //一番近い絵の位置を求める
            foreach (var forPic in fukuroPics)
            {
                float dis = Vector3.Distance(this.transform.position, forPic.transform.position);
                if (dis < minDis)//disの方が小さかったら、それを代入して更新する
                {
                    minDis = dis;//距離間を代入して上書き
                    nearestPic = forPic;//絵に新しいオブジェクトを入れて上書き
                    Debug.Log("midDis:" + minDis);
                }
            }

            //音関連
            chasingSE_f = true;
            gameManaSE.StopChasingSE();//音を下げる
            if (backHomeSE_f == true)//playerを見失った時1回だけ音を鳴らす
            {
                //playerを見失ったときにSEを鳴らす
                gameManaSE.BackHomeSE();
                backHomeSE_f = false;
            }
            //一番近い絵目的地を設定
            _enemy.destination = nearestPic.transform.position;
            Debug.Log("一番近い絵の目的地は:" + nearestPic);
            if (_enemy.remainingDistance <= 1)//目的地までの距離がわかる
            {
                enemySE.DisappearanceSE();
                _enemy.transform.gameObject.SetActive(false);
            }
        }
    }
    public void EnemyAgentStopMove()//enemyの動きを一時的に止め、攻撃する
    {
        _enemy.isStopped = true;
        //カメラを固定する
        firstPersonLook.enabled = false;
        //playerが移動出来ないようにする。
        firstPersonMovement.playerMoveFlag = false;
        //カメラをenemyの方に向ける
        player.transform.LookAt(this.transform);
    }
    //animationのeventsから呼ぶ。
    public void AttackFlagTrue()//。攻撃モーションの初めにtrueにする
    {
        attackFlag = true;
        EnemyAgentStopMove();
    }
    public void AttackFlagFalse()//攻撃モーションの終わりにfalseにする
    {
        attackFlag = false;
        EnemyAgentMove();
    }
}
