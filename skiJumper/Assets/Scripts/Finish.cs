using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] ParticleSystem finishLine;
    //temp for game finish
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            finishLine.Play();
            SceneManager.LoadScene(1);
        }
    }
}
