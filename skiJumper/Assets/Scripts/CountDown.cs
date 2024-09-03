using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] int countdownTime = 3;
    [SerializeField] SurfaceEffector2D surfaceEffector;

    [SerializeField] AudioClip countdown;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        surfaceEffector.enabled = false;
        audioSource.PlayOneShot(countdown);
        StartCoroutine(CountdownRoutine());
        
    }

    //run the 321 Go countdown
    private IEnumerator CountdownRoutine()
    {
        int currentTime = countdownTime;

        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString();
            yield return new WaitForSeconds(0.7f);
            currentTime--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);

        StartGame();
    }

    //start the player
    private void StartGame()
    {
        surfaceEffector.enabled = true;
    }
}

