﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimplePlatformController : MonoBehaviour {

    
    public float moveForce = 365f;
    public float maxSpeed = 10f;
    public float jumpForce = 1000.0f;
    public Transform groundCheck;
    public int hp = 100;
    public Text time;
    public static float playedTime = 0.0f;
    public AudioSource jumpSound;
    public AudioSource damageSound;
    public static float normalTime = 1f;


    private bool facingRight = true;
    private bool jump = false;
    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        setTimeText();


    }

    // Update is called once per frame
    void Update () {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
            jumpSound.Play();
        }
        setTimeText();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();

        if (jump)
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
        if(hp <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (Input.GetKeyDown("r"))
        {
            Time.timeScale = normalTime;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    void setTimeText() {
        playedTime += Time.deltaTime;
        time.text = "Time : " + playedTime.ToString("F2");
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject health = GameObject.FindGameObjectWithTag("Health");
        Slider hpbar = health.GetComponent<Slider>();
        if (collision.gameObject.tag == "ShootedEnemyBullet")
        {
            hp = hp - 5;
            hpbar.value = hpbar.value - 5;
            damageSound.Play();
        }
        if (collision.gameObject.tag == "Gun")
        {
            hp = hp - 20;
            hpbar.value = hpbar.value - 20;
            damageSound.Play();
        }
        if (collision.gameObject.tag == "ShootedBossBullet")
        {
            hp = hp - 15;
            hpbar.value = hpbar.value - 15;
            damageSound.Play();
        }
    }

  public string getPlayedTime()
    {
        return playedTime.ToString();
    }

}
