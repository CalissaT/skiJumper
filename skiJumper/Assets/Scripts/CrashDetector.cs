using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crash;
    [SerializeField] GameObject panel;

    //temp for player fail
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            crash.Play();
            Invoke("GameOver", 0.15f);
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
