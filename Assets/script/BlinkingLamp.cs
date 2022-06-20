using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLamp : MonoBehaviour
{
    [SerializeField] private GameObject lightObj;
    private float time = 0.4f;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
    }
    public void StartBlinkingLamp()
    {
        StartCoroutine("BlinkingLampCorutine");
    }
    IEnumerator BlinkingLampCorutine()
    {
        for (int count = 0; count < 1000; count++)
        {
            // Debug.Log("count :" + count);
            lightObj.gameObject.SetActive(true);
            //emissionをオン
            gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            yield return new WaitForSeconds(time);

            lightObj.gameObject.SetActive(false);
            //emissionをオフ
            gameObject.GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            yield return new WaitForSeconds(time);
        }
    }

    public void TurnOffBlinkingLamp()//ランプを非表示にする
    {
        this.gameObject.SetActive(false);
    }
}
