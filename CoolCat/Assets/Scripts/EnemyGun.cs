using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    public GameObject EnemyBullet; // enemybullet prefab
    public AudioSource enemyGun;   // enemybullet audiosource
    public float fireRate = 1F;
    public float nextFire = 0.0F;
    GameObject enemy;
    void Start () {
        enemy = GameObject.Find("enemy1");
    }
	
	void Update () {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if ((enemy.transform.position.x > min.x) && (enemy.transform.position.x < max.x) &&
              (enemy.transform.position.y > min.y) && (enemy.transform.position.y < max.y))
        {
            if (Time.time > nextFire)
            {
                Invoke("FireEnemyBullet", 1f);
                nextFire = Time.time + fireRate;
            }
        }
    }


    void FireEnemyBullet() {
        GameObject mouse = GameObject.Find("hero");
        if(mouse != null) {
            //instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);
            //set the bullet's initial position
            bullet.transform.position = transform.position;
            //compute the bullet's direction towards the player
            Vector2 direction = mouse.transform.position - bullet.transform.position;
            //set the bullet's direction
            bullet.GetComponent<EnemyBulletController>().SetDirection(direction);
            //enemy gunshot audio
            enemyGun.Play();
        }
    }
}
