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
    [SerializeField] int scoreDecrease = 5;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Button startButton;
    [SerializeField] GameObject newsCanvas;

    public bool isRun = false;
    public int score = 100;
    public TextNewsSpeedController speedController;

    private float lastSecond = 0f;

    // Start is called before the first frame update
    void Start()
    {

        startButton.onClick.AddListener(StartGame);

        // Mulai memanggil DecreaseScore setiap detik
        InvokeRepeating("DecreaseScore", 0f, 1f);

        newsCanvas.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRun)
        {
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
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
            lastSecond = timeToDisplay;
        }
    }

    void ChangeColorText(Color color)
    {
        timerText.color = color;
    }

    void DecreaseScore()
    {
        if (isRun & timeRemaining <= 0)
        {
            // Kurangi skor sebanyak scoreDecrease setiap detik
            score = Mathf.Max(score - scoreDecrease, 0); // Pastikan skor tidak kurang dari 0

            // Teks skor
            scoreText.text = "Skor: " + score.ToString();

            // Debug untuk memantau nilai-nilai
            Debug.Log("Skor Saat Ini: " + score);
        }
    }

    public void StartGame()
    {
        isRun = true;

        startButton.gameObject.SetActive(false);
        newsCanvas.gameObject.SetActive(true);

        if (speedController != null)
        {
            speedController.StartAppearAnimation();
            speedController.EnableAnimation();
        }
    }
}
