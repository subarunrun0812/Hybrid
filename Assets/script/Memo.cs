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
        firstPersonLook.StopPlayerRotation();
        MemoUI.SetActive(true);
    }
    public void MemoUIOFF()
    {
        firstPersonLook.enabled = true;
        firstPersonLook.StartPlayerRotation();
        MemoUI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            MemoUIOFF();
    }
}
