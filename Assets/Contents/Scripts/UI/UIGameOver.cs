using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOver : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button mainMenuButton;

    public void Init()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }
    public void OnMainMenuButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.MainMenu);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
