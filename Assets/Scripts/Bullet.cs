using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // sound effect
    public AudioClip desctructionSound;
    public AudioClip shootSound;
    public float speed = 50f;
    private Rigidbody2D rb;

    void Start()
    {
        AudioSource.PlayClipAtPoint(shootSound, transform.position);
        rb = GetComponent<Rigidbody2D>();

        
        // Establecer la velocidad inicial en la dirección de la rotación
        rb.velocity = transform.up * speed;
        transform.Rotate(0, 0, 90);
    }

    void Update()
    {
        // No necesitas modificar la velocidad aquí si ya la configuraste en Start()
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
            AudioSource.PlayClipAtPoint(desctructionSound, transform.position);
        }
    }
}
