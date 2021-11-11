using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMover2D : MonoBehaviour
{
    public float speed = 5.0f;
    public Boundary randomPosition;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity =  Random.insideUnitCircle * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var contact = other.GetContact(0);
        rb.velocity = contact.normal * rb.velocity.magnitude;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log(gameObject.name + " collide with " + other.gameObject.name);

        // if (other.gameObject.name == "TopBound" || other.gameObject.name == "BottomBound")
        // {
        //     var vel = rb.velocity;
        //     vel.y *= -1.0f;
        //     rb.velocity = vel;
        // }
        // else
        // {
        //     if (other.gameObject.name == "LeftBound" || other.gameObject.name == "RightBound")
        //     {
        //         var vel = rb.velocity;
        //         vel.x *= -1.0f;
        //         rb.velocity = vel;
        //     }
        //     else
        //     {
        //         rb.velocity *= -1;
        //     }
        // }
    }
}