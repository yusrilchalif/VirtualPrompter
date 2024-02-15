using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextNewsSpeedController : MonoBehaviour
{
    public TextMeshProUGUI karaokeText;
    public Color[] colors; // Array warna yang akan digunakan
    public float colorChangeSpeed = 1.0f;

    private int currentColorIndex = 0;
    private float colorChangeTimer = 0.0f;

    void Start()
    {
        SetNextColor();
    }

    void Update()
    {
        colorChangeTimer += Time.deltaTime;

        if (colorChangeTimer >= 1.0f / colorChangeSpeed)
        {
            SetNextColor();
            colorChangeTimer = 0.0f;
        }
    }

    void SetNextColor()
    {
        karaokeText.color = colors[currentColorIndex];
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
    }
}
