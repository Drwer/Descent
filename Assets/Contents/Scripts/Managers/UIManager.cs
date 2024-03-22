using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UIManager;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public Transform UIContainer;

    public static UIManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<UIManager>();
            if (_instance == null)
                Debug.LogError("UIManager not found, can't create singleton object");
            return _instance;
        }
    }
    public enum GameUI
    {
        NONE,
        Loading,
        MainMenu,
        HighestScore,
        Options,
        Gameplay,
        Pause,
        GameOver,
        GameWon,
    }
    private Dictionary<GameUI, IGameUI> registeredUIs = new Dictionary<GameUI, IGameUI>();

    private void Awake()
    {
        foreach (IGameUI enumeratedUI in UIContainer.GetComponentsInChildren<IGameUI>(true))
        {
            RegisterUI(enumeratedUI.GetUIType(), enumeratedUI);
        }
        Debug.Log(registeredUIs.Count);
        ShowUI(GameUI.NONE);
    }
    public void RegisterUI(GameUI UIType, IGameUI UIToRegister)
    {
        registeredUIs.Add(UIType, UIToRegister);
        UIToRegister.Init();
    }
    public void ShowUI(GameUI UIType)
    {
        foreach (KeyValuePair<GameUI, IGameUI> kvp in registeredUIs)
        {
            kvp.Value.SetActive(kvp.Key == UIType);
        }
    }
}
