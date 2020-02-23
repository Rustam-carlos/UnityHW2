using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // нам не нужно указывать счет вручную, т.к. он будет накапливаться
    // поэтому скрываем его с помощью этой команды
    [HideInInspector]
    // публичный счет игрока
    public float score;
    // текст, в который выводится счет
    public Text scoreText;
    // игрок
    public Transform player;

    // лучший счет игрока
    float bestScore;
    // в этот текст выводим сколько игрок набрал в игре
    public Text gameOverScoreText;
    // в этот текст выводим лучший счет игрока за все игры
    public Text bestScoreText;
    // логическая переменная для проверки кончилась ли игра
    bool isGameEnded = false;

    void Update()
    {
        // если игра не закончилась
        if (isGameEnded == false)
        {
            // приравниваем счет к позиции игрока по z
            score = player.transform.position.z;
            // выводим счет в текст в целочисленном формате (без дробной части)
            scoreText.text = score.ToString("0");
        }

    }

    public void SetBestScore()
    {
        // игра закончена
        isGameEnded = true;

        // Если мы играем не в первый раз
        if (PlayerPrefs.HasKey("BestScore"))
        {
            // получаем наш лучший счет из реестра
            bestScore = PlayerPrefs.GetFloat("BestScore");
        }
        else // иначе, если мы играем в первый раз
        {
            // лучший счет равен текущему счету
            bestScore = score;
            // записываем результат в реестр
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        // если в текущей игре мы набрали больше, чем наш лучший счет
        if (bestScore < score)
        {
            // обновляем наш лучший счет
            bestScore = score;
            // записываем результат в реестр
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }

        // выводим все значения в тексты
        gameOverScoreText.text = "Your Score: " + score.ToString("0");
        bestScoreText.text = "Your Best Score: " + bestScore.ToString("0");
    }

}
