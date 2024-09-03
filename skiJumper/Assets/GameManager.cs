using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private List<int> highScores = new List<int>();
    private const int maxScores = 3;

    void Awake()
    {
        //ensure only one GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadHighScores();
    }

    //adds a new score and updates the high scores list
    public void AddNewScore(int score)
    {
        highScores.Add(score);
        highScores.Sort((a, b) => b.CompareTo(a)); //sort scores in descending order

        //ensure we only keep the top `maxScores` scores
        if (highScores.Count > maxScores)
        {
            highScores.RemoveAt(maxScores);
        }

        SaveHighScores();
    }

    //retrieves the high scores list
    public List<int> GetHighScores()
    {
        return new List<int>(highScores); //return a copy to prevent external modification
    }

    //save the high scores using PlayerPrefs
    private void SaveHighScores()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + i, highScores[i]);
        }

        PlayerPrefs.Save();
    }

    //load the high scores from PlayerPrefs
    private void LoadHighScores()
    {
        highScores.Clear();
        for (int i = 0; i < maxScores; i++)
        {
            if (PlayerPrefs.HasKey("HighScore" + i))
            {
                highScores.Add(PlayerPrefs.GetInt("HighScore" + i));
            }
            else
            {
                break;
            }
        }
    }
}
