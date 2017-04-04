﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public LayerMask whatToHit;

    Transform firePoint;

    // Use this for initialization
    void Start()
    {
        firePoint = transform.FindChild("firePoint");
        if (firePoint == null)
        {
            Debug.LogError("No firePoint");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y); //firePoint asset does not exist yet
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition) * 100); //Debug line for bullet trajectory
        if (hit.collider != null)
        {
            Debug.DrawLine(firePointPosition, hit.point, Color.red); //Change debug line color to red when hitting something
        }
    }
}
