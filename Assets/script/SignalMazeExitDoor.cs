using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SignalMazeExitDoor : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void Enter_ExitDoor()
    {
    }
    public void EndExplosion()
    {
        Debug.Log("EndExplosionが呼び出された");
        audioMixer.SetFloat("SilentVolume", -80);
    }
}
