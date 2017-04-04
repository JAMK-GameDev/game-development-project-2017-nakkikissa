using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour {
    public GameObject EnemyBullet; // enemybullet prefab
	// Use this for initialization
	void Start () {
        Invoke("FireEnemyBullet", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
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
        }
    }
}
