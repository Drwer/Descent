using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button mainMenuButton;
    public Button commandsButton;
    public Button volumeButton;

    public void Init()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
        commandsButton.onClick.AddListener(OnCommandsButtonClick);
        volumeButton.onClick.AddListener(OnVolumeButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnMainMenuButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.MainMenu);
    }
    private void OnCommandsButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Commands);
    }
    private void OnVolumeButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Volume);
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
