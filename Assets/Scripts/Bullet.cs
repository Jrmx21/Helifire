using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
        private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed);

    }
    void OnBecameInvisible()
    {
        // Destruir la bala cuando salga de la pantalla
        Destroy(gameObject);
    }
   void OnTriggerEnter2D(Collider2D other)
   {
    
         if (other.gameObject.tag == "Enemy")
         {
              Animator enemyAnimator = other.GetComponent<Animator>();
            enemyAnimator.Play("DestroyAnimation");
            Destroy(other.gameObject, 0.5f);
            Destroy(this.gameObject);
         }
   }
}
