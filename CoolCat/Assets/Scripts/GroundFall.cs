using UnityEngine;
using System.Collections;

public class GroundFall : MonoBehaviour
{

    public float fallDelay = 0.1f;
    public AudioSource fallSound;


    private Rigidbody2D rb2d;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay);
            fallSound.Play();
        }
    }

    void Fall()
    {
        rb2d.isKinematic = false;
    }



}