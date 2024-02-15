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

    private void Start()
    {
        StartAppearAnimation();

        // Menambahkan listener untuk tombol mempercepat
        speedUpButton.onClick.AddListener(SpeedUpAnimation);

        // Menambahkan listener untuk tombol memperlambat
        slowDownButton.onClick.AddListener(SlowDownAnimation);
    }

    void StartAppearAnimation()
    {
        transform.position = new Vector3(transform.position.x, initialY, transform.position.z); // Set posisi awal

        // Menggunakan DoTween untuk menganimasikan pergerakan dari bawah ke atas
        transform.DOMoveY(targetY, duration)
            .SetEase(Ease.OutFlash) // Anda dapat mengganti Ease sesuai keinginan
            .OnComplete(AnimationComplete); // Panggil method ini saat animasi selesai
    }

    void AnimationComplete()
    {
        // Method yang dipanggil saat animasi selesai
        Debug.Log("Animasi selesai!");
    }

    // Method untuk mempercepat animasi
    void SpeedUpAnimation()
    {
        duration /= 2.0f; // Misalnya, mengurangi durasi menjadi setengah dari sebelumnya
        StartAppearAnimation(); // Mulai ulang animasi dengan durasi baru
    }

    // Method untuk memperlambat animasi
    void SlowDownAnimation()
    {
        duration *= 2.0f; // Misalnya, meningkatkan durasi menjadi dua kali lipat dari sebelumnya
        StartAppearAnimation(); // Mulai ulang animasi dengan durasi baru
    }
}
