using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500f;
        private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed * Time.deltaTime);

    }
    void OnBecameInvisible()
    {
        Destroy(this);
    }
   void OnTriggerEnter2D(Collider2D other)
   {
    
         if (other.gameObject.tag == "Enemy")
         {
              Destroy(other.gameObject);
              Destroy(this.gameObject);
         }
   }
}
