using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowMotion : MonoBehaviour {

    private bool superJump = false;

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
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyMovementController enemyScript = enemy.GetComponent<enemyMovementController>();
        enemyScript.speed = 0f;
        yield return new WaitForSeconds(8);
        enemyScript.speed = 2.0f;
    }
}
