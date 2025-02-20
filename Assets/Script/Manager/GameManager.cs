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
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if(_enemyManager!= null)
        {
            _enemyManager.Init(this);
        }

        DontDestroyOnLoad(gameObject);

        _enemyManager = FindObjectOfType<MiniGameEnemyManager>();
        
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
