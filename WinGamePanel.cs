using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinGamePanel : MonoBehaviour
{
    public Button homeButton;
    public Button nextLevelButton;
    public GameObject player;
    public List<LevelControler> ListlLevelControlers;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
        homeButton.onClick.AddListener(OnHomeButtonClick);
    }

    void OnNextLevelButtonClick()
    {
        DataGameManager.Instance.currentLevel++;
        PlayerPrefs.SetInt("PlayerScore",PlayerData.score);
        PlayerPrefs.SetInt("PlayerHP",PlayerData.HP);
        StartCoroutine(LoadingController.Instance.GotoScene("Game"));
        player.transform.position = ListlLevelControlers[DataGameManager.Instance.currentLevel].starttransform.position;
        Time.timeScale = 1;
        PlayerData.HP = 50;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
    }
    void OnHomeButtonClick()
    {
        StartCoroutine(LoadingController.Instance.GotoScene("Home"));
        player.transform.position = ListlLevelControlers[DataGameManager.Instance.currentLevel].starttransform.position;
        Time.timeScale = 1;
        PlayerData.HP = 50;
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
    }
}
