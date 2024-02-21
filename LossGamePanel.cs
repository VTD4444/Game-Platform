using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LossGamePanel : MonoBehaviour
{
    public Button playAgainButton;
    public Button homeButton;
    public GameObject player;
    public List<LevelControler> ListlLevelControlers;


    private void Awake()
    {
        playAgainButton.onClick.AddListener(OnPlayAgainButtonClick);
        homeButton.onClick.AddListener(OnHomeButtonClick);
    }

    void OnPlayAgainButtonClick()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        StartCoroutine(LoadingController.Instance.GotoScene("Game"));
        player.transform.position = ListlLevelControlers[DataGameManager.Instance.currentLevel].starttransform.position;
        Time.timeScale = 1;
        PlayerData.HP = 50;
    }

    void OnHomeButtonClick()
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.click);
        StartCoroutine(LoadingController.Instance.GotoScene("Home"));
        player.transform.position = ListlLevelControlers[DataGameManager.Instance.currentLevel].starttransform.position;
        Time.timeScale = 1;
        PlayerData.HP = 50;
    }
}
