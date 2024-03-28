using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIComm : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button nextButton;

    public void Init()
    {
        nextButton.onClick.AddListener(OnNextButtonClick);
    }
    public void OnNextButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.Gameplay);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
