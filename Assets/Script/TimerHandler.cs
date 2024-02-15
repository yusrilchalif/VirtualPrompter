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

    public bool isRun = false;
     
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
    }

    void ChangeColorText(Color color)
    {
        timerText.color = color;
    }
}
