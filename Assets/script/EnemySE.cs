using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemyの効果音を出すスクリプト
public class EnemySE : MonoBehaviour
{

    [SerializeField] private EnemyController enemyController;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource3d;
    [SerializeField] private EnemyAttackDetector enemyAttDet;
    [SerializeField] private AudioClip shoutSeClip;
    [SerializeField] private AudioClip emptyAttack3Clip;//攻撃する時(空振りも含む)
    [SerializeField] private AudioClip hitAttack3Clip;//playerにhitした時
    [SerializeField] private AudioClip walkLeftClip;
    [SerializeField] private AudioClip walkRightClip;
    [SerializeField] private AudioClip disappearanceClip;

    //Enemyの効果音の設定。animationからコマを選択して、その時に音を鳴らす
    public void ShoutSE()
    {
        audioSource3d.PlayOneShot(shoutSeClip);
    }
    public void Attack3SE()//playerが死んだ時に音を鳴らす.event関数から呼んでいる
    {
        if (enemyAttDet.hitSE == true)
        {
            //攻撃がプレイヤーに当たった時の音
            audioSource3d.PlayOneShot(hitAttack3Clip);
        }
        else
        {
            //空振りのときの音
            audioSource3d.PlayOneShot(emptyAttack3Clip);
        }
    }
    //Inspectorのevent関数から呼んでいる
    public void EnemyWalkLeftSE()
    {
        audioSource3d.PlayOneShot(walkLeftClip);
        enemyController.EnemyAgentMove();
    }
    //Inspectorのevent関数から呼んでいる
    public void EnemyWalkRightSE()
    {
        audioSource3d.PlayOneShot(walkRightClip);
        enemyController.EnemyAgentMove();
    }

}
