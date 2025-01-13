using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : EnemyManager
{
    // enemy bullet
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float fireRate = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Fire
        if (Time.time >= fireRate)
        {
            Instantiate(enemyBullet, FirePoint.position, FirePoint.rotation);
            fireRate = Time.time + 1f;
        }
    }
}
