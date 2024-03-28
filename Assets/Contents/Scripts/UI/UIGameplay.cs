using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameplay : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;
    public void Init() {}
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
