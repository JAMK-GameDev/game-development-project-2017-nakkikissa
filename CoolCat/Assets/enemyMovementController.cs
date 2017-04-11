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
    bool facing = false;
    bool noFloor = false;
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<BoxCollider2D>().bounds.extents.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.tag == "Player")
        {
            if (facing == false)
            {
                Vector3 currRot = myTrans.eulerAngles;
                currRot.y += 180;
                myTrans.eulerAngles = currRot;
                speed = 0;

            }
            else if (facing == true)
            {
                speed = 0;
            }

        }
    }

    void FixedUpdate()
    {
        //Check if there is ground in front of us before moving forward
        Vector2 lineCastPos = myTrans.position + myTrans.right * myWidth;
        //Debug.DrawLine(lineCastPos, lineCastPos - Vector2.up, Color.black);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos - Vector2.up, enemyMask);
        //  Debug.DrawLine(lineCastPos, lineCastPos + myTrans.right.ToVector2() * .07f, Color.black);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos + myTrans.right.ToVector2() * .07f, enemyMask);

        //if theres no ground or if blocked, turn around 
        if ((!isGrounded && noFloor == false) || isBlocked)
        {
            
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
            if (!isGrounded) {
                noFloor = true;
            }
        }
        if (facing == true)
        {
            facing = false;
        }
        else if (facing == false)
        {
            facing = true;
        }
        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = myTrans.right.x * speed;
        myBody.velocity = myVel;
    }
}
