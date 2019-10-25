using UnityEngine;
using UnityEngine.UI;

public class StartMenu : GameMenu
{
    [HideInInspector] public Text Title;
    [HideInInspector] public Button StartButton;
    [HideInInspector] public Button SettingButton;
    void Awake()
    {
        Title = gameObject.transform.Find("Title").GetComponent<Text>();
        StartButton = gameObject.transform.Find("StartButton").GetComponent<Button>();
        SettingButton = gameObject.transform.Find("SettingButton").GetComponent<Button>();
    }
}
