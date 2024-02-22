using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterAreaTest : MonoBehaviour
{
    //public UnityEvent ShowCanvas;
    public GameObject canvasChangeScene;

    // Start is called before the first frame update
    void Start()
    {
        canvasChangeScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasChangeScene.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasChangeScene.SetActive(false);
        }
    }
}
