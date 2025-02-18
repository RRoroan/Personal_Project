using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Text dialogueText;
    public string[] dialogue;
    public float wordSpeed;
    public int index;
    public bool playerIsClosed;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject HelpPanel;
    [SerializeField] private GameObject LobbyButton;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && playerIsClosed)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                ResetText();
            }
            else
            {
                dialoguePanel.SetActive(true);
                HelpPanel.SetActive(false);
                StartCoroutine(Typing());
            }
        }
        if(dialogueText.text == dialogue[index])
        {
            continueButton.SetActive(true);
        }

        if (index == dialogue.Length - 1)
        {
            LobbyButton.SetActive(true);
        }
        else
        {
            LobbyButton.SetActive(false);
        }
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = " ";
            StartCoroutine(Typing());
        }
        else
        {
            ResetText();
        }
    }

    public void ResetText()
    {
        dialogueText.text = " ";
        index = 0;
        dialoguePanel.SetActive(false);
        HelpPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClosed = true;
            HelpPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClosed = false;
            ResetText();
        }
    }
}
