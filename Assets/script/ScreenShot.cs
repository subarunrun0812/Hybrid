using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenShot : MonoBehaviour
{
    int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ScreenCapture.CaptureScreenshot("image_SS" + cnt.ToString() + ".png");
            Debug.Log("screenshot");
            cnt++;
        }
    }
}