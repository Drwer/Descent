using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICommands : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button optionsButton;

    public void Init()
    {
        optionsButton.onClick.AddListener(OnOptionsButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnStartButtonClick() { }
    private void OnOptionsButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Options);
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
