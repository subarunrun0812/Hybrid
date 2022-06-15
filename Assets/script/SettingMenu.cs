using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingMenu : MonoBehaviour
{
    [SerializeField] private Slider mouseSlider;//マウス感度を変更する
    [SerializeField] private FirstPersonLook firstPersonLook;
    [SerializeField] private TextMeshProUGUI t_mouseValue;

    private void Start()
    {
        t_mouseValue.text = $"{mouseSlider.value.ToString("N1")}";//小数点第2以下を切り捨て
    }
    public void MouseSensitivity()//マウス感度を変更する関数
    {
        float scale = mouseSlider.value;
        firstPersonLook.sensitivity = scale;//マウス感度の値を変更する
        t_mouseValue.text = $"{mouseSlider.value.ToString("N1")}";//小数点第2以下を切り捨て
    }
}
