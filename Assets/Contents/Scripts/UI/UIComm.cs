using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComm : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button nextPageButton;

    public void Init()
    {
        nextPageButton.onClick.AddListener(OnNextPageButtonClick);
    }
    public void OnNextPageButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Gameplay);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
