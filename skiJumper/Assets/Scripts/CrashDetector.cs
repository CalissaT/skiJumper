using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] ParticleSystem crash;
    [SerializeField] GameObject panel;

    [SerializeField] AudioClip gasp;
    [SerializeField] AudioSource audioSource;

    //when player hits something
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            crash.Play();
            audioSource.PlayOneShot(gasp);
            Invoke("GameOver", 0.15f);
        }
    }

    //player dies bring game over screen
    public void GameOver()
    {
        Time.timeScale = 0;
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
