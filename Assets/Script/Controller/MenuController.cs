using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// -------------------------
// Menu Controller:
// - Controls result, start, 
//     setting, game menu
// -------------------------
public class MenuController : MonobehaviorSingleton<MenuController>
{
    private GameObject inGamePrefab;
    private GameObject resultPrefab;
    private GameObject startPrefab;
    private GameObject settingPrefab;
    private GameObject canvasPrefab;
    private GameObject eventPrefab;
    private Canvas canvas;
    private GameObject eventSystem;
    private List<GameMenu> activeMenus;
    private GameMenu inGameMenu;

    void Awake()
    {
        inGamePrefab = Resources.Load<GameObject>("Prefab/UIPrefab/InGamePrefab");
        resultPrefab = Resources.Load<GameObject>("Prefab/UIPrefab/ResultPrefab");
        startPrefab = Resources.Load<GameObject>("Prefab/UIPrefab/StartPrefab");
        settingPrefab = Resources.Load<GameObject>("Prefab/UIPrefab/SettingPrefab");
        canvasPrefab = Resources.Load<GameObject>("Prefab/UIPrefab/Canvas");
        eventPrefab = Resources.Load<GameObject>("Prefab/UIPrefab/EventSystem");

        activeMenus = new List<GameMenu>();
    }

    void Start()
    {
        Validate(startPrefab);
    }

    public void AddStartMenuFunctionality(StartMenu startMenu)
    {
        startMenu.StartButton.onClick.AddListener(delegate
        {
            Debug.Log("Clicked");
            DestroyMenu(startMenu);
            this.gameObject.AddComponent<GameController>();
            Validate(inGamePrefab);
        });

        startMenu.SettingButton.onClick.AddListener(delegate
        {
            Validate(settingPrefab);
        });
    }

    public void AddSettingMenuFunctionality(SettingMenu settingMenu)
    {
        settingMenu.ResumeButton.onClick.AddListener(delegate
        {
            DestroyMenu(settingMenu);
        });

        settingMenu.MusicButton.onClick.AddListener(delegate
        {
        });

        settingMenu.EffectButton.onClick.AddListener(delegate
        {
        });

        settingMenu.MainMenuButton.onClick.AddListener(delegate
        {
            DestroyMenu(settingMenu);
            Validate(startPrefab);
        });
    }

    public void AddInGameMenuFunctionality(InGameMenu inGameMenu)
    {
        this.inGameMenu = inGameMenu;
        inGameMenu.SpawnButton.onClick.AddListener(delegate
        {
            Player.Instance.Stack();
        });
    }

    public void AddResultMenuFunctionality(ResultMenu resultMenu)
    {
        resultMenu.RestartButton.onClick.AddListener(delegate
        {
            DestroyMenu(resultMenu);
            Validate(inGamePrefab);
            //RESTART FUNCTION IMPLEMENTATION
        });

        resultMenu.ReviveButton.onClick.AddListener(delegate
        {
            DestroyMenu(resultMenu);
            Validate(inGamePrefab);
            //RESUME FUNCTION IMPLMENTATION
        });
    }

    public void GameEnd()
    {
        DestroyMenu(inGameMenu);
        Validate(resultPrefab);
        //PAUSE FUNCTION IMPLEMENTATION
    }

    private Canvas SceneCanvas
    {
        get
        {
            if (canvas == null)
            {
                canvas = FindObjectOfType<Canvas>();
                if (canvas == null)
                {
                    canvas = Instantiate(canvasPrefab).GetComponent<Canvas>();
                }
            }
            return canvas;
        }
    }

    private void SpawnEventSystem()
    {
            if (eventSystem == null)
            {
                eventSystem = GameObject.Find("EventSystem");
            Debug.Log(eventSystem);
                if (eventSystem == null)
                {
                    eventSystem = Instantiate(eventPrefab);
                }
            }
    }

    private void Validate(GameObject prefab)
    {
        GameMenu menu = prefab.GetComponent<GameMenu>();
        bool exists = false;
        if (menu != null)
        {
            foreach (GameMenu m in activeMenus)
            {
                if (m.GetType() == menu.GetType())
                {
                    exists = true;
                    break;
                }
            }

            if (!exists)
                CreateMenu(menu);
        }
    }

    public void CreateMenu(GameMenu menu)
    {
        GameObject menuObject = Instantiate(menu.gameObject, SceneCanvas.transform);
        SpawnEventSystem();
        GameMenu menuComponent = menuObject.GetComponent<GameMenu>();
        System.Type type = menuComponent.GetType();

        if (type == typeof(StartMenu))
        {
            AddStartMenuFunctionality((StartMenu)menuComponent);
        }
        else if (type == typeof(SettingMenu))
        {
            AddSettingMenuFunctionality((SettingMenu)menuComponent);
        }
        else if (type == typeof(InGameMenu))
        {
            AddInGameMenuFunctionality((InGameMenu)menuComponent);
        }
        else if (type == typeof(ResultMenu))
        {
            AddResultMenuFunctionality((ResultMenu)menuComponent);
        }
        activeMenus.Add(menuComponent);
    }

    private void DestroyMenu(GameMenu menu)
    {
        if (menu != null)
        {
            activeMenus.Remove(menu);
            Destroy(menu.gameObject);
        }
    }
}
