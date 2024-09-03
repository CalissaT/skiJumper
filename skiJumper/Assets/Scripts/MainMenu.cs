using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI scoresText;
    //starts the game
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    //opens the scores menu
    public void DisplayScoresMenu()
    {
        panel.SetActive(true);
        DisplayHighScores();
    }

    //closes the score menu
    public void CloseScoresMenu()
    {
        panel.SetActive(false);
    }

    //displays top 3 scores in the score menu
    public void DisplayHighScores()
    {
        scoresText.text = "";

        List<int> highScores = GameManager.instance.GetHighScores();
        for (int i = 0; i < highScores.Count; i++)
        {
            scoresText.text += (i + 1) + ": " + highScores[i] + "\n\n";
        }

    }


}
