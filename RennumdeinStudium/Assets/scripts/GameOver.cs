using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    private static GameOver gameOver;

    public static bool GamePause = false;

    public GameObject GameOverMenuUI;
    public Text highscore;
    private int score;

    public static GameOver Instance             //andere Skripte können auf Funktionen aus der Klasse zugreifen
    {
        get
        {
            if (gameOver == null)
            {
                gameOver = GameObject.FindObjectOfType<GameOver>();
            }
            return gameOver;
        }
    }

    public void Dead()
    {

        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GamePause = true;

    }

    public void LoadGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
