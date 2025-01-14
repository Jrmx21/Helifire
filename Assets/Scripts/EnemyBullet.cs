using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        rb.velocity = new Vector2(0, -speed * Time.deltaTime);

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Animator playerAnimator = other.GetComponent<Animator>();
            playerAnimator.Play("DestroyAnimation");
            // Resta heart
            
            Destroy(other.gameObject, 0.5f);
            Destroy(this.gameObject);
        }
    }
}
