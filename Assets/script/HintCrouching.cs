using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintCrouching : MonoBehaviour
{
	[SerializeField] private KeyCodeExplanation keyCodeExplanation;
	private float _time;
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			_time += Time.deltaTime;
			if (_time > 5f)//ヒントを出すまでの時間
			{
				keyCodeExplanation.MoveKeyCodeExplanation(40, "C", "しゃがみ");
				this.gameObject.SetActive(false);
			}
		}
	}
	void OnTriggerExit(Collider col)
	{
		_time = 0;
	}
	private void Update()
	{
		Debug.Log("Time: " + _time);
	}
}
