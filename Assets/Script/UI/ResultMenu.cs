using UnityEngine;
using UnityEngine.UI;

public class ResultMenu : GameMenu
{
    [HideInInspector] public Button RestartButton;
    [HideInInspector] public Button ReviveButton;
    [HideInInspector] Image BestImage;
    [HideInInspector] Image CurrentImage;
    [HideInInspector] Text BestScore;
    [HideInInspector] Text CurrentScore;

    void Awake()
    {
        RestartButton = gameObject.transform.Find("RestartButton").GetComponent<Button>();
        ReviveButton = gameObject.transform.Find("ReviveButton").GetComponent<Button>();
        //BestImage = gameObject.transform.Find("Images").Find("BestImage").GetComponent<Image>();
        //CurrentImage = gameObject.transform.Find("Images").Find("CurrentImage").GetComponent<Image>();
        //BestScore = gameObject.transform.Find("Images").Find("BestScore").GetComponent<Text>();
        //CurrentScore = gameObject.transform.Find("Images").Find("CurrentScore").GetComponent<Text>();
    }
}
