﻿using UnityEngine;
using System.Collections;

public class PickupPowerup : MonoBehaviour
{
    private bool superJump = false;
    GameObject enemyGameObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


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

            Destroy(gameObject);
        }

    }


    IEnumerator Timer()
    {
        GameObject player = GameObject.Find("hero");
        SimplePlatformController playerScript = player.GetComponent<SimplePlatformController>();
        playerScript.maxSpeed = 40f;
        yield return new WaitForSeconds(8);
        playerScript.maxSpeed = 10f;
    }

}

