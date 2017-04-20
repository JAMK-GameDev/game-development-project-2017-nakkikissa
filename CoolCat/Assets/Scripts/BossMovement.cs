﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D myBody;
    Transform myTrans;
    int facingLeft = 1;
    GameObject hero;
    GameObject boss;
    float newposition;


    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        hero = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
        newposition = boss.transform.position.y - 2;
    }


    void FixedUpdate()
    {
        if (boss.transform.position.y < newposition)
        {
                Vector2 myVel = myBody.velocity;
                myVel.y = myTrans.position.y * speed;
                myBody.velocity = myVel;
                if (boss.transform.position.y > newposition)
                {
                    newposition = boss.transform.position.y - 2;
                  }           
        }
        else if (boss.transform.position.y > newposition)
        {         
                Vector2 myVel = myBody.velocity;
                myVel.y = -myTrans.position.y * speed;
                myBody.velocity = myVel;
                if (boss.transform.position.y < newposition)
                {
                    newposition = boss.transform.position.y + 2;
                }          
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            BossFlip();
        }
    }
    void BossFlip()
    {
        if (hero.transform.position.x < boss.transform.position.x && facingLeft == 1)
        {
            // speed = 0;
        }
        else if (hero.transform.position.x < boss.transform.position.x && facingLeft == 0)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
            speed = 0;
            facingLeft = 1;
        }
        else if (hero.transform.position.x > boss.transform.position.x && facingLeft == 0)
        {
            // speed = 0;
        }
        else if (hero.transform.position.x > boss.transform.position.x && facingLeft == 1)
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
            facingLeft = 0;
            speed = 0;
        }
    }
}
