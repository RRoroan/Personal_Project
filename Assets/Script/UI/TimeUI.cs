using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GameTimeText;
    [SerializeField] private TextMeshProUGUI GameHighTimeText;
    private float gameTime = 0f;
    private float gameHighTime = 0f;
    private int minutes;
    private int seconds;
    private bool timerGoing;
    private Coroutine timeCoroutine;

    private void Awake()
    {
    }
    void Start()
    {
        GameHighTimeText.text = "High Score:" + gameHighTime.ToString();
        gameHighTime = PlayerPrefs.GetFloat("High Score", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            gameTime += Time.deltaTime;
            GameTimeText.text = gameTime.ToString();
            minutes = Mathf.FloorToInt(gameTime / 60);
            seconds = Mathf.FloorToInt(gameTime % 60);
            GameTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return null;
        }
    }

    public void StopTimer()
    {
        timerGoing = false;
        if(timeCoroutine != null)
        {
            StopCoroutine(timeCoroutine);
            timeCoroutine = null;
        }

        if (gameTime > gameHighTime)
        {
            gameHighTime = gameTime;
            PlayerPrefs.SetFloat("High Score", gameHighTime);
            PlayerPrefs.Save();
            UpdateHighScore();
        }
    }

    public void StartTimer()
    {
        gameTime = 0f;
        timerGoing = true;
        timeCoroutine = StartCoroutine(UpdateTimer());
        
    }

    private void UpdateHighScore()
    {
       int minutes = Mathf.FloorToInt(gameTime / 60);
       int seconds = Mathf.FloorToInt(gameTime % 60);
       GameHighTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
