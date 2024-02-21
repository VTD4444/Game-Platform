using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHomeManager : MonoBehaviour
{
    [Header("Button")]
    public Button playButton;
    public Button level1Button;
    public Button level2Button;
    public Button settingButton;
    public Button quitButton;
    public Button closeLevelPanelButton;
    public Button closeSettingPanelButton;
    [Header("Panel")]
    public GameObject levelPanel;
    public GameObject settingPanel;

    public void OnPlayButtonClick()
    {
        levelPanel.SetActive(true);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
    }

    public void OnCloseButtonClick()
    {
        levelPanel.SetActive(false);
        settingPanel.SetActive(false);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
    }

    public void OnSettingButtonClick()
    {
        settingPanel.SetActive(true);
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
    }

    public void OnLevel1ButtonClick()
    {
        DataGameManager.Instance.currentLevel = 0;
        StartCoroutine(LoadingController.Instance.GotoScene("Game"));
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        AudioManager.Instance.musicSource.Pause();
    }

    public void OnLevel2ButtonClick()
    {
        DataGameManager.Instance.currentLevel = 1;
        StartCoroutine(LoadingController.Instance.GotoScene("Game"));
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        AudioManager.Instance.musicSource.Pause();
    }
    public void OnQuitButtonClick() 
    {
        Application.Quit();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
    }
}
