using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorLockKey : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip mistakeClip;
    [SerializeField] private AudioClip correctClip;
    [SerializeField] private AudioClip unlockDoorClip;
    [SerializeField] Material[] m_Array;
    private bool[] pushArray = new bool[9];
    [ColorUsage(false)] public Color colorOff;
    [ColorUsage(false)] public Color _1green;
    [ColorUsage(false)] public Color _2yellow;
    [ColorUsage(false)] public Color _3lightBlue;
    [ColorUsage(false)] public Color _4red;
    [ColorUsage(false)] public Color _5purple;
    [ColorUsage(false)] public Color _6blue;
    [ColorUsage(false)] public Color _7gray;
    [ColorUsage(false)] public Color _8brown;
    [ColorUsage(false)] public Color _9pink;

    private int total;//4つ押したら、リセット or アンロック
    private bool correct;//1つでも間違えた場合、falseにする
    public bool doorflag = true;//doorの開ける音は一回だけにする
    void Start()
    {
        StartCoroutine("ResetColorCorutine");

    }
    //正解の色[green,yellow,red,pink]
    private void InputButton()
    {
        audioSource.PlayOneShot(buttonClip);
        total += 1;//押した数足していく

        if (total == 4)//4つボタンを押した処理
        {
            if (correct)
            {
                StartCoroutine("OpenDoorCorutine");
            }
            else
            {
                audioSource.PlayOneShot(mistakeClip);
            }
            //リセット
            StartCoroutine("ResetColorCorutine");
            total = 0;
        }
    }
    IEnumerator OpenDoorCorutine()//正解時、ドアを開ける
    {
        audioSource.PlayOneShot(correctClip);
        yield return new WaitForSeconds(0.6f);
        if (doorflag)
        {
            audioSource.PlayOneShot(unlockDoorClip);
            doorflag = false;
        }
        Debug.Log("暗号装置キーを解除した");
    }
    IEnumerator ResetColorCorutine()//色とボタンを押した真偽をリセットする
    {

        for (int i = 0; i < pushArray.Length; i++)
        {
            pushArray[i] = false;
        }
        yield return new WaitForSeconds(0.3f);
        //materialのemmisionの数値を統一する
        for (int number = 0; number < m_Array.Length; number++)
        {
            m_Array[number].SetColor("_EmissionColor", colorOff);
        }
        //不正解の時のみ、falseにするため、リセットのタイミングでtrueにする
        correct = true;
    }
    public void Button_1green()//正解
    {
        m_Array[0].SetColor("_EmissionColor", _1green);
        if (pushArray[0] == false)
        {
            pushArray[0] = true;
            InputButton();
        }
    }
    public void Button_2yellow()//正解
    {
        m_Array[1].SetColor("_EmissionColor", _2yellow);
        if (pushArray[1] == false)
        {
            pushArray[1] = true;
            InputButton();
        }
    }
    public void Button_3lightBlue()
    {
        m_Array[2].SetColor("_EmissionColor", _3lightBlue);
        correct = false;
        if (pushArray[2] == false)
        {
            pushArray[2] = true;
            InputButton();
        }
    }
    public void Button_4red()//正解
    {
        m_Array[3].SetColor("_EmissionColor", _4red);
        if (pushArray[3] == false)
        {
            pushArray[3] = true;
            InputButton();
        }
    }
    public void Button_5purple()
    {
        m_Array[4].SetColor("_EmissionColor", _5purple);
        correct = false;
        if (pushArray[4] == false)
        {
            pushArray[4] = true;
            InputButton();
        }
    }
    public void Button_6blue()//正解
    {
        m_Array[5].SetColor("_EmissionColor", _6blue);
        if (pushArray[5] == false)
        {
            pushArray[5] = true;
            InputButton();
        }
    }
    public void Button_7gray()
    {
        m_Array[6].SetColor("_EmissionColor", _7gray);
        correct = false;
        if (pushArray[6] == false)
        {
            pushArray[6] = true;
            InputButton();
        }
    }
    public void Button_8brown()
    {
        m_Array[7].SetColor("_EmissionColor", _8brown);
        correct = false;
        if (pushArray[7] == false)
        {
            pushArray[7] = true;
            InputButton();
        }
    }
    public void Button_9pink()
    {
        m_Array[8].SetColor("_EmissionColor", _9pink);
        correct = false;
        if (pushArray[8] == false)
        {
            pushArray[8] = true;
            InputButton();
        }
    }

}
