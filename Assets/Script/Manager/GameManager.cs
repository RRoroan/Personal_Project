using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player {  get; private set; }
    public FollowCamera _camera {  get; private set; }
    private MiniGameEnemyManager _enemyManager;
    private DoorManager _doorManager;
    private MiniGameEnemy enemy;
    private float waveTime = 0;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
        _camera = FindAnyObjectByType<FollowCamera>();
        _enemyManager = FindObjectOfType<MiniGameEnemyManager>();
        _doorManager = FindObjectOfType<DoorManager>();

    }

    private void Start()
    {
       
    }

    private void Update()
    {
        if (_doorManager.playerInGameZone)
        {
            _enemyManager.StartGame();
        }
        else if (!_doorManager.playerInGameZone)
        {
            _enemyManager.StopGame();
        }
    }
}
