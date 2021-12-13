using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public string nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonToChangeLevel()
    {

        //loads the scene written in the inspector
        SceneManager.LoadScene(nextLevel);

    }

    public void ButtonToExitGame()
    {
        Application.Quit();
    }
}
