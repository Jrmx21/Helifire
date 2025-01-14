using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickEnemy : EnemyManager
{
       // enemy bullet
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float fireRate = 2f;
    
    private Animation anim;
    // Start is called before the first frame update
    
    void Start()
    {
        anim=GetComponent<Animation>();
        speed = 400f;
          //    Initial direction
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1f * speed * Time.deltaTime, 0);
        

    }

    public void animDeath()
    {
       anim.Play("DestroyAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        // 1 de 6 probabiiidad de disparar
        // Fire
        if (Time.time >= fireRate)
        {

            if (Random.Range(0, 2) == 1)
            {
                Instantiate(enemyBullet, FirePoint.position, FirePoint.rotation);
            }
            fireRate = Time.time + 1f;
            // alternador de pararse mientras dispara y moverse
          
        }

    }
    
}
