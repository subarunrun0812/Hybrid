using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SignalMazeExitDoor : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] private SilentScript silentScript;

    public void Enter_ExitDoor()
    {
    }
    public void EndExplosion()
    {
        silentScript.TurnOffSilent();
        audioMixer.SetFloat("SilentVolume", -80);
    }
}
