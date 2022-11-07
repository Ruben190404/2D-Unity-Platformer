using System;
using Unity.VisualScripting;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public bool canShoot;
    public float timer;
    public float timeBetweenShots;
    public GameObject bullet;
    public Transform firePoint;
    public Transform target;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenShots)
            {
                canShoot = true;
                timer = 0;
            }
        }

        if (canShoot)
        {
            canShoot = false;
            Instantiate(bullet, firePoint.position, Quaternion.identity);
        }
    }
}
