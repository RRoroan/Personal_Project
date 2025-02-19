using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private GameObject GameUI;
    [SerializeField] private TextMeshProUGUI GameTimeText;
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

    public void SetGameTime(float gameTime)
    {
        GameTimeText.text = gameTime.ToString();
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        GameTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
