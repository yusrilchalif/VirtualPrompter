using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public float startingTime = 60f; // Waktu awal timer dalam detik
    public float penaltyRate = 5f; // Tingkat pengurangan point per detik ketika timer negatif
    public int startingPoints = 100; // Jumlah point awal

    private float currentTime;
    private int currentPoints;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        currentTime = startingTime;
        currentPoints = startingPoints;

        // Mulai timer
        InvokeRepeating("UpdateTimer", 0f, 1f); // Panggil UpdateTimer setiap detik
    }

    private void UpdateTimer()
    {
        currentTime -= 1f;

        // Ubah warna teks menjadi merah jika timer negatif
        if (currentTime < 0)
        {
            timerText.color = Color.red;

            // Kurangi point setiap detik jika timer negatif
            currentPoints -= Mathf.FloorToInt(penaltyRate);
            UpdatePointsText();
        }

        // Hentikan timer jika waktu telah habis
        if (currentTime <= 0)
        {
            currentTime = 0;
            CancelInvoke("UpdateTimer");
        }

        UpdateTimerText();
    }

    private void UpdateTimerText()
    {
        // Format waktu menjadi menit:detik
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");

        // Tampilkan waktu pada teks timer
        timerText.text = minutes + ":" + seconds;
    }

    private void UpdatePointsText()
    {
        // Tampilkan jumlah point pada teks points
        pointsText.text = "Points: " + currentPoints;
    }
}
