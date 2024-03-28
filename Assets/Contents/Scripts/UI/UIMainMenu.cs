using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button newGameButton;
    public Button highestScoreButton;
    public Button optionsButton;
    public Button quitButton;
    public Button weaponButton;

    public void Init()
    {
        newGameButton.onClick.AddListener(OnNewGameButtonClick);
        highestScoreButton.onClick.AddListener(OnHighestScoreButtonClick);
        optionsButton.onClick.AddListener(OnOptionsButtonClick);
        quitButton.onClick.AddListener(OnQuitButtonClick);
        weaponButton.onClick.AddListener(OnWeaponButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnStartButtonClick() {}

    private void OnNewGameButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Lore);
        SetActive(false);
    }
    private void OnHighestScoreButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.HighestScore);
    }
    private void OnOptionsButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Options);
    }
    private void OnWeaponButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.WeaponChange);
    }
    private void OnQuitButtonClick()
    {
        Application.Quit();
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
