using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    // [SerializeField]
    // private WinPanel winPanel;
    public GameObject winPanel;
    Score score;
    void Start() 
    {
        //включаем скрипт в начале игры чтобы управлять им
        score = GetComponent<Score>();
    }
    public void Restart()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(1);
    }
    public void NextLivel()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void WinGame()
    {
        winPanel.SetActive(true);
        score.SetBestScore();
    }

    // Update is called once per frame
    public void EndGame()
    {
        gameOverMenu.SetActive(true);
        score.SetBestScore();
    }
}
