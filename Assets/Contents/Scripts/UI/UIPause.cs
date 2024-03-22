using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPause : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button returnButton;
    public Button endRunButton;
    public Button optionButton;
    public Button quitButton;

    public void Init()
    {
        returnButton.onClick.AddListener(OnReturnButtonClick);
        endRunButton.onClick.AddListener(OnEndRunButtonClick);
        optionButton.onClick.AddListener(OnOptionButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public void OnReturnButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Gameplay);
    }
    public void OnEndRunButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.MainMenu);
    }
    public void OnOptionButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Options);
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
