using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;
    public Button mainMenuButton;

    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;
    public Slider musicSlider;
    public Slider sfxSlider;
    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            LoadSFX();
        }
        else
        {
            SetSFX();
        }
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        //musicMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SetMusicVolume();
    }
    public void SetSFX()
    {
        float volume = sfxSlider.value;
        //sfxMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
    private void LoadSFX()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFX();
    }
    public void Init()
    {
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    }
    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }
    private void OnMainMenuButtonClick()
    {
        GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.MainMenu);
    }
    public UIManager.GameUI GetUIType() { return UIType; }
}
