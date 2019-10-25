using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : GameMenu
{
    [HideInInspector] public Button ResumeButton;
    [HideInInspector] public Text Title;
    [HideInInspector] public Button MusicButton;
    [HideInInspector] public Button EffectButton;
    [HideInInspector] public Button MainMenuButton;
    [HideInInspector] void Awake()
    {
        ResumeButton = gameObject.transform.Find("ResumeButton").GetComponent<Button>();
        Title = gameObject.transform.Find("Center").Find("Title").GetComponent<Text>();
        MusicButton = gameObject.transform.Find("Center").Find("MusicButton").GetComponent<Button>();
        EffectButton = gameObject.transform.Find("Center").Find("EffectButton").GetComponent<Button>();
        MainMenuButton = gameObject.transform.Find("Center").Find("MainMenuButton").GetComponent<Button>();
    }
}
