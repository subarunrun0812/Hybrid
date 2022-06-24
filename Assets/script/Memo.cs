using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memo : MonoBehaviour
{
    [SerializeField] private GameObject MemoUI;
    [SerializeField] private FirstPersonLook firstPersonLook;
    void Start()
    {
        MemoUI.SetActive(false);
    }
    public void MemoUION()
    {
        firstPersonLook.enabled = false;
        MemoUI.SetActive(true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            MemoUIOFF();
    }
    public void MemoUIOFF()
    {
        firstPersonLook.enabled = true;
        MemoUI.SetActive(false);
    }
}
