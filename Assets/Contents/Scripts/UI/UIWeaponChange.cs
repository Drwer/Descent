using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponChange : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button mainMenuButton;

    public UIManager.GameUI GetUIType()
    {
        return UIType;
    }
    public void Init()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }
    private void OnMainMenuButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.MainMenu);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
