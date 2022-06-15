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
    //AudioClip型を変数ShoutSE宣言します。
    //publicで宣言してInspectorで設定できるようにします。
    [SerializeField] private AudioClip shoutSeClip;
    [SerializeField] private AudioClip emptyAttack3Clip;//攻撃する時(空振りも含む)
    [SerializeField] private AudioClip hitAttack3Clip;//playerにhitした時
    [SerializeField] private AudioClip walkLeftClip;
    [SerializeField] private AudioClip walkRightClip;
    [SerializeField] private AudioClip disappearanceClip;

    //Enemyの効果音の設定。animationからコマを選択して、その時に音を鳴らす
    public void ShoutSE()
    {
        //イベントが呼ばれたらAudioClip型の変数shoutSeClipを
        //流すようにするよ！
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
    public void EnemyWalkLeftSE()
    {
        audioSource3d.PlayOneShot(walkLeftClip);
        enemyController.EnemyAgentMove();
    }
    public void EnemyWalkRightSE()
    {
        audioSource3d.PlayOneShot(walkRightClip);
        enemyController.EnemyAgentMove();
    }
    public void DisappearanceSE()
    {
        // audioSource2d.volume = 1.0f;
        // audioSource2d.PlayOneShot(disappearanceClip);
    }


}
