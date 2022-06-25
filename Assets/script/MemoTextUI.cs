using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MemoTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI t_memo;
    [SerializeField] private string contents;//memoの文章をinspectorから設定する
    void Start()
    {
        t_memo.text = contents;
    }
}
