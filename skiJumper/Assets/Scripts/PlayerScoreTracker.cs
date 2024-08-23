using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreTracker : MonoBehaviour
{
    private int score = 0;
    private float airTime = 0;
    private float rotation = 0f;
    private float startingRot;
    private bool grounded;

    [SerializeField] TextMeshProUGUI scoreText;

    //player lands, calculate score and reset vars
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            //prevent score from being calculated unless actually doing trick
            if (airTime > 0.3f)
            {
                CalculateTrickScore();
            }
                ResetTrickVars();

        }
    }

    //player leaves ground, calculate capture starting angle
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;
            startingRot = transform.eulerAngles.z;

        }
    }

    //calculate the trick score for flips
    private void CalculateTrickScore()
    {
        int fullRots = (int)(rotation / 360f);
        float partialRots = rotation % 360f;

        //player does backflip
        if (rotation > 0)
        {
            score += fullRots * 1500;
            score += (int)(partialRots * 3);
        }
        //player does frontflip
        else
        {
            score += System.Math.Abs(fullRots) * 1000;
            score += (int)(System.Math.Abs(partialRots) * 2);
        }
    }

    //reset the trick variables
    private void ResetTrickVars()
    {
        airTime = 0f;
        rotation = 0f;
    }

    public int GetScore()
    {
        return score;
    }

    void Update()
    {
        if (!grounded)
        {
            //air time
            airTime += Time.deltaTime;
            score += (int)(100 * Time.deltaTime);

            //rotation amount
            float currentRot = transform.eulerAngles.z;
            rotation += Mathf.DeltaAngle(startingRot, currentRot);
            startingRot = currentRot;

        }

        scoreText.text = score.ToString();
    }

}
