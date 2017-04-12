using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : MonoBehaviour
{
    float speed;
    Vector2 _direction; // The direction of the bullet
    bool isReady = false; //to know when the bullet direction is set

    //set default values in awake function
    void Awake()
    {
        speed = 7f;
        isReady = false;
    }
    // Use this for initialization
    void Start()
    {

    }
    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized; // to get an unit vector
        isReady = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isReady == true)
        {
            //get bullet current position
            Vector2 position = transform.position;
            //new position
            position += _direction * speed * Time.deltaTime;
            transform.position = position;

            //bottom-left & top-right 
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            //if bullet goes outside the screen -> destroy      
            if ((transform.position.x < min.x) || (transform.position.x > max.x) ||
              (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);

            }
        }

    }
}
