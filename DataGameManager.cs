using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataGameManager : MonoBehaviour
{
    public static DataGameManager Instance;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public int currentLevel;
}