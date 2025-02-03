using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [Header("Torpedo settings")]
    // Cambia direccion de 1 a 4,7 
    [SerializeField] private float speed = 2f;
    [SerializeField] private  float explodeCoord;


    [SerializeField] private bool isTorpedoPlayed = false;
    [Header("Audio")]
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip torpedoSound;
    private Animator animation;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        animation = GetComponent<Animator>();
        AudioSource.PlayClipAtPoint(shootSound, transform.position);

        // dado de 1 a 4,7
        explodeCoord = Random.Range(1f, 4.7f);

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.y <= -explodeCoord)
        {
            rb.velocity = new Vector2(-speed * 2, 0);



            if (!isTorpedoPlayed)
            {
                // -180 degree
                animation.Play("Torpedo");
                rb.rotation = -180;
                isTorpedoPlayed = true;
                AudioSource.PlayClipAtPoint(torpedoSound, transform.position);
            }



        }
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
