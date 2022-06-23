using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class caricatureTrap : MonoBehaviour
{
	[SerializeField] private GameObject enemy;
	[SerializeField] private int time;
	[SerializeField] private GameObject enemyWatiSpot;//絵の後ろについてるenemy待機の場所にあるobj
	[SerializeField] private int picPosY;//絵の待機~登場時のy
	[SerializeField] private EnemyController enemyController;
	[SerializeField] private Material eye_m;//fukuroの目のmaterial
	private Animator animator;//enemyのanimator
	private NavMeshAgent enemyNavmesh;
	private GameObject[] trapsArray;//enemyが追いかけている時はtrapは発動しないようにする
	private List<Collider> trapsList = new List<Collider>();
	void Start()//enemy以外のオブジェクトからenemyの表示を制御する
	{
		enemy.SetActive(false);
		enemyNavmesh = enemy.GetComponent<NavMeshAgent>();
		animator = enemy.GetComponent<Animator>();
		eye_m.color = Color.black;
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
		// animator.SetTrigger("ResetTrigger");
		enemy.transform.position = new Vector3(
			enemyWatiSpot.transform.position.x,
			picPosY,
			enemyWatiSpot.transform.position.z
		);
		//一度通ったトラップn秒発動した
		this.gameObject.GetComponent<Collider>().enabled = false;
		StartCoroutine("HideTrapCorutine");

		enemy.SetActive(false);//威嚇のanimationを再生するため
		enemy.SetActive(true);
		//壁から登場する前の待機
		enemy.transform.LookAt(this.gameObject.transform.position);//飛び出す方向に向kう
		eye_m.color = new Color32(209, 0, 0, 1);//ほぼ赤色

		enemy.transform.DOLocalMove(new Vector3(
			this.transform.position.x,
			picPosY,
			this.transform.position.z
			), time).OnComplete(() =>
		{//enemyが壁から登場しanimationをした後に追いかける
			enemyController.EnemyAgentMove();
		});
	}

	IEnumerator HideTrapCorutine()//トラップが発動するのをn秒やめる
	{
		yield return new WaitForSeconds(20f);
		this.gameObject.GetComponent<Collider>().enabled = true;
	}
	void Update()
	{
		//enemyがいない場合はもう一度トラップを起動する
		if (enemy.activeSelf == true)
		{
			eye_m.color = new Color32(209, 0, 0, 1);//ほぼ赤色

			// enemyの瞬間移動を防ぐため
			for (int item = 0; item < trapsList.Count; item++)
			{
				trapsList[item].enabled = false;
				Debug.Log("trapsのcolliderが非表示になった");
			}
		}
		else
		{
			eye_m.color = Color.black;

			//enemyをもう一度出すことが可能になる
			for (int item = 0; item < trapsList.Count; item++)
			{
				trapsList[item].enabled = true;
			}
		}
	}
}
