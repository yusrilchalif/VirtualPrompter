using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNewsScene : MonoBehaviour
{
    [SerializeField] Button yesBtn, noButton;
    [SerializeField] GameObject canvasUI;

    // Start is called before the first frame update
    void Start()
    {
        yesBtn.onClick.AddListener(GoToTest);
        noButton.onClick.AddListener(DisableCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToTest()
    {
        LoadSceneManager.instance.GoToTestScene();
    }

    public void DisableCanvas()
    {
        canvasUI.SetActive(false);
    }
}
