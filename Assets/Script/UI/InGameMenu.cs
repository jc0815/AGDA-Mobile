using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : GameMenu
{
    [HideInInspector] public Button SpawnButton;
    void Awake()
    {
        SpawnButton = gameObject.transform.Find("SpawnButton").GetComponent<Button>();
    }
}
