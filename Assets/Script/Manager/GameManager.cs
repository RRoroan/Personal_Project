using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public TextMeshPro highScoreText;
    public float highscore = 0f;
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
        UpdateHighScoreinGame();
        highScoreText.text = "High Score:" + highscore.ToString();
        highscore = PlayerPrefs.GetFloat("High Score", 0f);
    }

    public void UpdateHighScoreinGame()
    {
        if (_timeUI.gameTime > _timeUI.gameHighTime)
        {
            highscore = _timeUI.gameTime;
            PlayerPrefs.SetFloat("High Score", highscore);
            PlayerPrefs.Save();
            _timeUI.UpdateHighScore();
        }
    }


    private void Update()
    {
       
    }
}
