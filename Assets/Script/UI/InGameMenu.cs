using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : GameMenu
{
    [HideInInspector] public Button SpawnButton;
    public Text ScoreText;
    void Awake()
    {
        SpawnButton = gameObject.transform.Find("SpawnButton").GetComponent<Button>();
        ScoreText = gameObject.transform.Find("ScoreText").GetComponent<Text>();
    }
}
