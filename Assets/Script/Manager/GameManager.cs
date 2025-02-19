using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player { get; private set; }
    public FollowCamera _camera { get; private set; }
    private MiniGameEnemyManager _enemyManager;
    private DoorManager _doorManager;
    private MiniGameEnemy enemy;
    private float gameTime = 0f;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
        _camera = FindAnyObjectByType<FollowCamera>();
        _enemyManager = FindObjectOfType<MiniGameEnemyManager>();
        _doorManager = FindObjectOfType<DoorManager>();
        enemy = GetComponent<MiniGameEnemy>();

    }

    private void Start()
    {

    }

    private void Update()
    {
        _doorManager.SetGameTime(gameTime);

        if (_doorManager.playerInGameZone)
        {
            _enemyManager.StartGame();
            gameTime += Time.deltaTime;
            
        }
        else if (!_doorManager.playerInGameZone)
        {
            _enemyManager.StopGame();
        }
        if (_enemyManager.IsAnyEnemyTouchPlayer())
        {
            _enemyManager.StopGame();
        }
    }
}
