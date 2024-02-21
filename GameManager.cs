using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<LevelControler> ListlLevelControlers;
    public PlayerMovement player;
    private void Awake()
    {
        Instantiate(ListlLevelControlers[DataGameManager.Instance.currentLevel]);
        player.transform.position = ListlLevelControlers[DataGameManager.Instance.currentLevel].starttransform.position;
    }
}