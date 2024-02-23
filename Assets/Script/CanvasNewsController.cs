using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasNewsController : MonoBehaviour
{
    [SerializeField] GameObject canvasNews;
    [SerializeField] Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        canvasNews = GetComponent<GameObject>();
        canvasNews.SetActive(false);

        startButton.onClick.AddListener(StartNews);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNews()
    {
        StartCoroutine(ShowNewsCanvas());
    }

    IEnumerator ShowNewsCanvas()
    {
        canvasNews.SetActive(true);

        yield return new WaitForSeconds(2);
    }
}
