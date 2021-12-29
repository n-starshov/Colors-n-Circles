using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMover2D : MonoBehaviour
{
    public float speed = 5.0f;
    public float rndKoef = .1f;

    [SerializeField] private Rigidbody2D rb;
    private Vector2 _randomSpeedVector;

    private void Awake()
    {
        _randomSpeedVector = Random.insideUnitCircle * speed;
        rb.velocity =  _randomSpeedVector;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var contact = other.GetContact(0);
        var randomreflection = Random.insideUnitCircle * rndKoef;
        var reflect = Vector2.Reflect((rb.velocity + randomreflection).normalized, contact.normal);
        rb.velocity = reflect * _randomSpeedVector.magnitude + (-contact.point.normalized * 0.3f);
    }
}