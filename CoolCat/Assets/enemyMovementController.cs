using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;
    int facingLeft = 0;
    bool noFloor = false;
    GameObject hero; 
    GameObject[] enemiess; 
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<BoxCollider2D>().bounds.extents.x;
        hero =  GameObject.Find("hero");
        enemiess = GameObject.FindGameObjectsWithTag("Enemy");
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            enemyFlip();
        }
    }

    void FixedUpdate()
    {
        //Check if there is ground in front of us before moving forward
        Vector2 lineCastPos = myTrans.position + myTrans.right * myWidth;
       // Debug.DrawLine(lineCastPos, lineCastPos - Vector2.up, Color.black);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos - Vector2.up, enemyMask);
       //   Debug.DrawLine(lineCastPos, lineCastPos + myTrans.right.ToVector2() * .07f, Color.black);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos + myTrans.right.ToVector2() * .07f, enemyMask);

        //if theres no ground or if blocked, turn around 
        if ((!isGrounded && noFloor == false) || isBlocked)
        {
 
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
            if (!isGrounded)
            {
                noFloor = true;
            }
            switch (facingLeft)
            {
                case 0:
                    facingLeft = 1;
                    return;
                case 1:
                    facingLeft = 0;
                    return;
            }
           
            
        }
        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
    void enemyFlip() {
        foreach (GameObject enemy in enemiess)
        {
            if (hero.transform.position.x < enemy.transform.position.x && facingLeft == 1)
            {
                speed = 0;
            }
            else if (hero.transform.position.x < enemy.transform.position.x && facingLeft == 0)
            {
                Vector3 currRot = myTrans.eulerAngles;
                currRot.y += 180;
                myTrans.eulerAngles = currRot;
                speed = 0;
                facingLeft = 1;
            }
            else if (hero.transform.position.x > enemy.transform.position.x && facingLeft == 0)
            {
                speed = 0;
            }
            else if (hero.transform.position.x > enemy.transform.position.x && facingLeft == 1)
            {
                Vector3 currRot = myTrans.eulerAngles;
                currRot.y += 180;
                myTrans.eulerAngles = currRot;
                facingLeft = 0;
                speed = 0;
            }
        }
    }
}
