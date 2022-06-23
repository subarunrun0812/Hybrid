using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(AudioSource))]
public class Locker : MonoBehaviour
{
	[SerializeField] private GameObject player;
	[SerializeField] private Crouch crouch;
	[SerializeField] private GameObject lockerParent;
	private AudioSource audioSource;
	[SerializeField] private AudioClip openSE;
	[SerializeField] private AudioClip closeSE;
	[SerializeField] private GameObject cube;
	public float openTime;
	public float closeTime;
	private bool inLocker = false;//lockerの中に入っていたらtrue

	void Start()
	{
		audioSource = this.gameObject.GetComponent<AudioSource>();
	}

	public void GoInsideLocker()
	{

		if (inLocker == false)//ロッカーに入っていないとき。
		{
			this.transform.DOLocalRotate(new Vector3(0, -60, 0), openTime);
			audioSource.PlayOneShot(openSE);

			//ロッカーの隙間から外を見るため、カメラの高さを高くする
			crouch.headToLower.localPosition = new Vector3
	   (crouch.headToLower.localPosition.x, crouch.crouchYHeadPosition = 1.75f, crouch.headToLower.localPosition.z);

			player.transform.DOMove((lockerParent.transform.position), openTime).OnComplete(() =>
			 {
				 this.transform.DOLocalRotate(new Vector3(0, 0, 0), closeTime);
				 audioSource.PlayOneShot(closeSE);
			 });



			inLocker = true;
		}
		else//ロッカーに入っているとき
		{
			this.transform.DOLocalRotate(new Vector3(0, -120, 0), openTime);
			audioSource.PlayOneShot(openSE);
			//ロッカーの隙間から外を見るため、カメラの高さを高くする
			crouch.headToLower.localPosition = new Vector3
		   (crouch.headToLower.localPosition.x, crouch.crouchYHeadPosition = 1.4f, crouch.headToLower.localPosition.z);

			player.transform.DOMove((cube.transform.position), openTime).OnComplete(() =>
			 {
				 this.transform.DOLocalRotate(new Vector3(0, 0, 0), closeTime);
				 audioSource.PlayOneShot(closeSE);
			 });
			inLocker = false;
		}
	}
}
