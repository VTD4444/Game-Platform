using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    public static LoadingController Instance;
    public Image Progressimage;
    public GameObject canvas;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        StartCoroutine(GotoScene("Home"));
    }

    public IEnumerator GotoScene(string scenename)
    {
        canvas.SetActive(true);
        Progressimage.fillAmount = 0;
        while (Progressimage.fillAmount < 1)
        {
            Progressimage.fillAmount += 0.005f;
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene(scenename);
        canvas.SetActive(false);        
    }
}