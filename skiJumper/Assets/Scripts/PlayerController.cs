using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float torqueValue = 15.5f;

    [SerializeField] ParticleSystem trail;
    //play particle effect behind player
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            trail.Play();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }


    void FixedUpdate()
    {
        //add torque to rigidbody that makes skiier flip
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddTorque(torqueValue);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddTorque(-torqueValue);
        }
    }
}
