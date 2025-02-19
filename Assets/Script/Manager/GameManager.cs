using System.Collections;
using System.Collections.Generic;
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
        player = FindAnyObjectByType<PlayerController>();
        _camera = FindAnyObjectByType<FollowCamera>();
        _enemyManager = FindObjectOfType<MiniGameEnemyManager>();
        _enemyManager.Init(this);
        _doorManager = FindObjectOfType<DoorManager>();
        enemy = GetComponent<MiniGameEnemy>();
        _timeUI = FindObjectOfType<TimeUI>();
    }

    

    public void StartMiniGame()
    {
        _doorManager.GameUI.SetActive(false);
        _enemyManager.StartGame();
        _timeUI.StartTimer();
    }

    public void GameOver()
    {
        _doorManager.GameUI.SetActive(true);
        StopAllCoroutines();
        _timeUI.StopTimer();
    }

    private void Update()
    {
        
        //_doorManager.SetGameTime(gameTime);

        //if (_doorManager.playerInGameZone)
        //{
        //    _enemyManager.StartGame();
        //    gameTime += Time.deltaTime;

        //}
        //else if (!_doorManager.playerInGameZone)
        //{
        //    _enemyManager.StopGame();
        //}
        //if (_enemyManager.IsAnyEnemyTouchPlayer())
        //{
        //    _enemyManager.StopGame();
        //}
    }
}
