using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using TMPro;

public class ChangeLanguage : MonoBehaviour
{
    //Dropdownを格納する変数
    [SerializeField] private TMP_Dropdown dropdown;
    public int lannum;//0 = 日本語,1 = 英語
    private void Start()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[PlayerPrefs.GetInt("language", 0)];
        Debug.Log("language : " + PlayerPrefs.GetInt("language"));
    }

    // オプションが変更されたときに実行するメソッド
    public void ChangeLanguageFunction()
    {
        //DropdownのValueが0のとき
        if (dropdown.value == 0)//日本語
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
            PlayerPrefs.SetInt("language", 0);
            PlayerPrefs.Save();
            lannum = 0;
        }
        //DropdownのValueが1のとき
        else if (dropdown.value == 1)//English
        {
            LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
            PlayerPrefs.SetInt("language", 1);
            PlayerPrefs.Save();
            lannum = 1;
        }
    }
}
