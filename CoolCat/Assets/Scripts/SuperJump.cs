using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour {
    private bool superJump = false;
    GameObject enemyGameObject;
    private AudioSource pickupSound;

    // Use this for initialization
    void Start () {
        pickupSound = GameObject.Find("Powerup_3 (1)").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
 

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            superJump = true;
            if (superJump)
            {
                other.GetComponent<SimplePlatformController>().StartCoroutine(Timer());
                superJump = false;

            }
            Debug.Log("pitäis soida");
            pickupSound.Play();
            Destroy(gameObject);
        }
            
        }


     IEnumerator Timer()
    {
        Debug.Log("Hei");
        GameObject player = GameObject.Find("hero");
        SimplePlatformController playerScript = player.GetComponent<SimplePlatformController>();
        playerScript.jumpForce = 2000.0f;
        yield return new WaitForSeconds(8);
        playerScript.jumpForce = 1000.0f;
    }
    }




