using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private GameObject HelpPanel;
    private SceneController controller;
    [SerializeField] private string SceneName;
    private bool playerIsClose;

    private void Awake()
    {
        controller = FindObjectOfType<SceneController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClose)
        {
            controller.LoadbySceneName(SceneName);
        }

    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
            HelpPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            HelpPanel.SetActive(false);
        }
    }



}
