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
          //    Initial direction
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1f * speed, 0);


    }

    // Update is called once per frame
    void Update()
    {
        // 1 de 6 probabiiidad de disparar
        // Fire
        if (Time.time >= fireRate)
        {

            if (Random.Range(0, 4) == 1)
            {
                Instantiate(enemyBullet, FirePoint.position, FirePoint.rotation);
            }
            fireRate = Time.time + 1f;
            // alternador de pararse mientras dispara y moverse
          
        }

    }
    
}
