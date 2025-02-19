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
    [SerializeField] public GameObject GameUI;
    [SerializeField] private TextMeshProUGUI GameTimeText;
    [SerializeField] public GameObject StartButton;
    [SerializeField] public GameObject TimeObj;
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
            TimeObj.SetActive(true);
            playerInGameZone = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        GameUI.SetActive(false);
        TimeObj.SetActive(false);
        playerInGameZone = false;
    }

    
}
