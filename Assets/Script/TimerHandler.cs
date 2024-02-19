using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeRemaining = 300f;
    [SerializeField] Color timeupColor = Color.red;
    [SerializeField] TextMeshProUGUI scoreText;

    public bool isRun = false;
    public int score = 100;
    public int scoreDecrease = 5;

    private float lastSecond = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isRun = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRun)
        {
            timeRemaining -= Time.deltaTime;

            if(timeRemaining <= 0)
            {
                //print("time out");
                ChangeColorText(timeupColor);
            }
            
            DisplayTimer(timeRemaining);
        }
    }

    void DisplayTimer(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        string sign = (timeToDisplay < 0) ? "-" : "";

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (Mathf.FloorToInt(timeToDisplay) != Mathf.FloorToInt(lastSecond))
        {
            DecreaseScore(scoreDecrease);
            lastSecond = timeToDisplay;
        }
    }

    void ChangeColorText(Color color)
    {
        timerText.color = color;
    }

    void DecreaseScore(int value)
    {
        if(timeRemaining <= 0)
        {
            // Kurangi skor sebanyak scoreDecreaseRate setiap detik
            int decreaseAmount = Mathf.CeilToInt(value * Mathf.Abs(Time.deltaTime));
            score = Mathf.Max(score - decreaseAmount, 0); // Pastikan skor tidak kurang dari 0

            // text score
            scoreText.text = "Score: " + score.ToString();

            // Tampilkan skor atau lakukan operasi lain yang diperlukan
            Debug.Log("Current Score: " + score);
        }
    }
}
