using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KeyDoor_Key : MonoBehaviour
{
	[SerializeField] private KeyDoor keyDoor;
	public void GetKey()//鍵を入手した時の処理
	{
		Debug.Log("GetKeyが呼ばれた");
		keyDoor.KeySE();//効果音を鳴らす
		this.gameObject.SetActive(false);
	}
}
