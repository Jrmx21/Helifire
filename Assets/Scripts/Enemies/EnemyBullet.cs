using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float speed = 5f;
    [SerializeField] private AudioClip shootSound;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -speed);

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            Destroy(this.gameObject);
            gameManager.subtractHealth(1);


        }
    }
}
