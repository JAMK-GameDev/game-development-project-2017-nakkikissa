using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour {
    public GameObject BossBullet; // enemybullet prefab
    public float fireRate = 0.3F;
    private float nextFire = 0.0F;
    void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            Invoke("FireBossBullet", 1f);
            nextFire = Time.time + fireRate;
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
