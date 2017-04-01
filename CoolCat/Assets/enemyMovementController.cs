using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour {
    public LayerMask enemyMask;
    public float speed;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;


	void Start () {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<BoxCollider2D>().bounds.extents.x;
	}
	

	void FixedUpdate () {
        //Check if there is ground in front of us before moving forward
        Vector2 lineCastPos = myTrans.position + myTrans.right * myWidth;
       /// Debug.DrawLine(lineCastPos, lineCastPos - Vector2.up, Color.black);
        bool isGrounded = Physics2D.Linecast(lineCastPos, lineCastPos - Vector2.up, enemyMask);
      //  Debug.DrawLine(lineCastPos, lineCastPos + myTrans.right.ToVector2() * .07f, Color.black);
        bool isBlocked = Physics2D.Linecast(lineCastPos, lineCastPos + myTrans.right.ToVector2() * .07f, enemyMask);

        //if theres no ground or if blocked, turn around 
        if (!isGrounded || isBlocked)
            {   
                Vector3 currRot = myTrans.eulerAngles;
                currRot.y += 180;
                myTrans.eulerAngles = currRot;

            }

                

        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = myTrans.right.x * speed;
        myBody.velocity = myVel;


    }
}
