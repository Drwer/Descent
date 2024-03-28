using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIVolume : MonoBehaviour, IGameUI
{
    public UIManager.GameUI UIType;

    public Button optionsButton;

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