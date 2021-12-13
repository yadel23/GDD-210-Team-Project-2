using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cntDownTimer : MonoBehaviour
{
    public Text timerTxt;
    public float startTime;
    private float currTime = 0f;



    void Start()
    {
        currTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= 1 * Time.deltaTime;

        timerTxt.text = "Timer: " + currTime.ToString("f0");

        if(currTime < 1)
        {
            Debug.Log("hello you suck");
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("LoseScene");
        }
    }
}
