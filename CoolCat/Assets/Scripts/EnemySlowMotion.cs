using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowMotion : MonoBehaviour {

    private bool freezing = false;

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

            freezing = true;
            if (freezing)
            {
                other.GetComponent<SimplePlatformController>().StartCoroutine(Timer());
                freezing = false;

            }

            Destroy(gameObject);
        }

    }


    IEnumerator Timer()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyMovementController enemyScript = enemy.GetComponent<enemyMovementController>();
        GameObject enemyGun = GameObject.FindGameObjectWithTag("Gun");
        EnemyGun enemyGunScript = enemyGun.GetComponent<EnemyGun>();
        enemyScript.speed = 0f;
        enemyGunScript.nextFire = 200f;
        yield return new WaitForSeconds(8);
        enemyScript.speed = 2.0f;
        enemyGunScript.nextFire = Time.time + enemyGunScript.fireRate;
    }
}
