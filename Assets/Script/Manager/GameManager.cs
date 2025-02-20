using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public PlayerController player { get; private set; }
    public FollowCamera _camera { get; private set; }
    private MiniGameEnemyManager _enemyManager;
    private DoorManager _doorManager;
    private MiniGameEnemy enemy;
    private TimeUI _timeUI;
    

    private void Awake()
    {


        Instance = this;
        _enemyManager = FindObjectOfType<MiniGameEnemyManager>();
        _enemyManager.Init(this);
        _doorManager = FindObjectOfType<DoorManager>();
        _timeUI = FindObjectOfType<TimeUI>();
    }

    

    public void StartMiniGame()
    {
        _doorManager.StartGame();
        _enemyManager.StartGame();
        _timeUI.StartTimer();
    }

    public void GameOver()
    {
        _timeUI.StopTimer();
        _doorManager.StoppingGame();
    }

    


    private void Update()
    {
       
    }
}
