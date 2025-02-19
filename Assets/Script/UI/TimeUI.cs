using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI GameTimeText;
    private float gameTime = 0f;
    private int minutes;
    private int seconds;
    private bool timerGoing;

    private void Awake()
    {
    }
    void Start()
    {
        
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
        StopCoroutine(UpdateTimer());
    }

    public void StartTimer()
    {
        gameTime = 0f;
        timerGoing = true;
        StartCoroutine(UpdateTimer());
        
    }
}
