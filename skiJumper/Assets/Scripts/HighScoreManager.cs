using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public int playerScore;

    //save the top 3 scores 
    public void SaveScore(int score)
    {
        int[] highScores = new int[3];
        for (int i = 0; i < 3; i++)
        {
            highScores[i] = PlayerPrefs.GetInt("HighScore" + i, 0);
        }

        for (int i = 0; i < 3; i++)
        {
            if (score > highScores[i])
            {
                //shift lower scores down
                for (int j = 2; j > i; j--)
                {
                    highScores[j] = highScores[j - 1];
                }

                //insert the new score
                highScores[i] = score;
                break;
            }
        }

        //save updated scores
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }
        PlayerPrefs.Save();

    }

}
