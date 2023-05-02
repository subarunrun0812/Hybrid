using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class caricatureTrap : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private int time;
    [SerializeField] private GameObject enemyWatiSpot;//enemyがActiveになった時の開始地点
    [SerializeField] private int picPosY;//絵の待機~登場時のy
    [SerializeField] private EnemyController enemyController;
    private Animator animator;//enemyのanimator
    private NavMeshAgent enemyNavmesh;
    private GameObject[] trapsArray;
    private List<Collider> trapsList = new List<Collider>();
    void Start()//enemy以外のオブジェクトからenemyの表示を制御する
    {
        enemy.SetActive(false);
        enemyNavmesh = enemy.GetComponent<NavMeshAgent>();
        animator = enemy.GetComponent<Animator>();
        //全てのtrapのcollider取得
        trapsArray = GameObject.FindGameObjectsWithTag("Trap");
        foreach (var item in trapsArray)
        {
            trapsList.Add(item.GetComponent<Collider>());
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if ((col.transform.gameObject.tag == "Player") || (col.transform.gameObject.tag == "BackRoomsDoor") || (col.transform.gameObject.tag == "NormalDoor"))
        {
            EntryEnemy();
        }
    }
    public void EntryEnemy()
    {
        Debug.Log("トラップが作動した");
        //enemyの威嚇animationからリセット
        enemy.transform.position = new Vector3(
            enemyWatiSpot.transform.position.x,
            picPosY,
            enemyWatiSpot.transform.position.z
        );
        //一度通ったトラップn秒発動した
        this.gameObject.GetComponent<Collider>().enabled = false;

        //威嚇のanimationを再生するため
        //一回、非アクティブにしないと、animatorがリセットされないから 
        enemy.SetActive(false);
        enemy.SetActive(true);
        //壁から登場する前の待機
        enemy.transform.LookAt(this.gameObject.transform.position);
        enemy.transform.DOLocalMove(new Vector3(
            this.transform.position.x,
            picPosY,
            this.transform.position.z
            ), time).OnComplete(() =>
        {//enemyが壁から登場しanimationをした後に追いかける
            enemyController.EnemyAgentMove();
        });
    }

    void Update()
    {
        //enemyが追いかけている時はtrapは発動しないようにする
        if (enemy.activeSelf == true)
        {
            // enemyの瞬間移動を防ぐため
            for (int item = 0; item < trapsList.Count; item++)
            {
                trapsList[item].enabled = false;
                Debug.Log("trapsのcolliderが非表示になった");
            }
        }
        //enemyがいない場合はトラップが作動するようにする
        else
        {
            //enemyをもう一度出すことが可能になる
            for (int item = 0; item < trapsList.Count; item++)
            {
                trapsList[item].enabled = true;
            }
        }
    }
}
