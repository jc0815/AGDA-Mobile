using UnityEngine;
using UnityEngine.UI;

public class ResultMenu : GameMenu
{
    [HideInInspector] public Button RestartButton;
    [HideInInspector] public Button ReviveButton;

    [HideInInspector] public Button MenuButton;
    [HideInInspector] Image BestImage;
    [HideInInspector] Image CurrentImage;
    [HideInInspector] public Text BestScoreText;
    [HideInInspector] public Text CurrentScoreText;

    void Awake()
    {
        RestartButton = gameObject.transform.Find("RestartButton").GetComponent<Button>();
        ReviveButton = gameObject.transform.Find("ReviveButton").GetComponent<Button>();
        MenuButton = gameObject.transform.Find("MenuButton").GetComponent<Button>();
        //BestImage = gameObject.transform.Find("Images").Find("BestImage").GetComponent<Image>();
        //CurrentImage = gameObject.transform.Find("Images").Find("CurrentImage").GetComponent<Image>();
        BestScoreText = gameObject.transform.Find("Scores").Find("BestScoreText").GetComponent<Text>();
        CurrentScoreText = gameObject.transform.Find("Scores").Find("CurrentScoreText").GetComponent<Text>();
    }

    public void AddScoreToResultMenu(int score) {
        
    }
    
    // TODO: create menu button and edit inside menu controller
}
