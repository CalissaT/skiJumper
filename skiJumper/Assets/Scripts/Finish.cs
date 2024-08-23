using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] ParticleSystem finishLine;
    [SerializeField] GameObject panel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] PlayerScoreTracker playerScoreTracker;

    //when player finishes
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            finishLine.Play();
            Invoke("FinishGame", 1.0f);
        }
    }

    ////player finishes bring game over screen
    public void FinishGame()
    {
        Time.timeScale = 0;
        scoreText.text = (playerScoreTracker.GetScore()).ToString();
        panel.SetActive(true);
    }

    //function for button
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    //function for button
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
