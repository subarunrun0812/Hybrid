using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RequiredItemMessage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI t_required;//必要な道具を表示するテキスト
    private float displayTime = 3f;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        t_required.text = "";
    }
    public void RequiredMessage(string message)//必要な道具をテキストで表示する
    {
        audioSource.Play();
        t_required.text = message;
        StartCoroutine("MessageCorutine");
    }
    private IEnumerator MessageCorutine()
    {
        yield return new WaitForSeconds(displayTime);
        t_required.text = "";
    }
}
