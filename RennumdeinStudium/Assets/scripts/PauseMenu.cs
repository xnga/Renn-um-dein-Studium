using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TUTORIAL https://www.youtube.com/watch?v=JivuXdrIHK0

public class PauseMenu : MonoBehaviour
{

    public static bool GamePause = false;

    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {

        PauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GamePause = false;

    }

    void Pause()
    {

        PauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GamePause = true;

    }

    public void LoadGame() {

        SceneManager.LoadScene(0);

    }
}