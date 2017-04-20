using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour {
    public GameObject BossBullet; // enemybullet prefab
    public float fireRate = 0.3F;
    private float nextFire = 0.0F;
    GameObject boss;
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    void Update()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if ((boss.transform.position.x > min.x) && (boss.transform.position.x < max.x) &&
                  (boss.transform.position.y > min.y) && (boss.transform.position.y < max.y))
        {
            if (Time.time > nextFire)
            {
                Invoke("FireBossBullet", 1f);
                nextFire = Time.time + fireRate;
            }
        }
    }


    void FireBossBullet()
    {
        GameObject mouse = GameObject.Find("hero");
        if (mouse != null)
        {
            //instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(BossBullet);
            //set the bullet's initial position
            bullet.transform.position = transform.position;
            //compute the bullet's direction towards the player
            Vector2 direction = mouse.transform.position - bullet.transform.position;
            //set the bullet's direction
            bullet.GetComponent<BossBulletController>().SetDirection(direction);
        }
    }
}
