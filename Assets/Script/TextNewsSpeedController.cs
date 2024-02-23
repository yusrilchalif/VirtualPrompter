using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class TextNewsSpeedController : MonoBehaviour
{
    public float duration = 2.0f;
    public float targetY = -200.0f;
    public float initialY = -400.0f; // Tambahkan variabel untuk posisi awal
    public Button speedUpButton;
    public Button slowDownButton;
    public Button endButton;

    private bool canAnimate = false; // Variabel untuk mengecek apakah animasi dapat dimainkan

    private void Start()
    {
        //startButton.onClick.AddListener(StartGame);

        // Menambahkan listener untuk tombol mempercepat
        speedUpButton.onClick.AddListener(SpeedUpAnimation);

        // Menambahkan listener untuk tombol memperlambat
        slowDownButton.onClick.AddListener(SlowDownAnimation);

        //endButton.onClick.AddListener()
    }

    public void StartAppearAnimation()
    {
        Debug.Log("StartAppearAnimation called");
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z);
        transform.DOMoveY(targetY, duration)
            .SetEase(Ease.OutFlash)
            .OnComplete(AnimationComplete);
    }

    void AnimationComplete()
    {
        // Method yang dipanggil saat animasi selesai
        Debug.Log("Animasi selesai!");
    }

    // Method untuk mempercepat animasi
    void SpeedUpAnimation()
    {
        Debug.Log("SpeedUpAnimation called");
        if (canAnimate)
        {
            duration /= 2.0f;
            Debug.Log("Speed+: " + duration.ToString());
            StartAppearAnimation();
        }
    }

    // Method untuk memperlambat animasi
    void SlowDownAnimation()
    {
        Debug.Log("AJAJJA");
        if (canAnimate)
        {
            duration *= 2.0f; // Misalnya, meningkatkan durasi menjadi dua kali lipat dari sebelumnya
            StartAppearAnimation(); // Mulai ulang animasi dengan durasi baru

            print("Speed-: " + duration.ToString());
        }
    }

    // Method untuk mengaktifkan animasi
    public void EnableAnimation()
    {
        canAnimate = true;
    }
}
