using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private GameObject GameUI;
    private MiniGameEnemyManager enemyManager;
    public bool playerInGameZone { get; private set; }

    private void Awake()
    {
        enemyManager = FindObjectOfType<MiniGameEnemyManager>();
    }
    private void Update()
    {
    }

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameUI.SetActive(true);
            playerInGameZone = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameUI.SetActive(false);
        playerInGameZone = false;
    }

}
