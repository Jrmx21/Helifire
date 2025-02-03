using System.Collections;
using UnityEngine;

public class StealthEnemy : EnemyManager
{
    [Header("ZigZag Movement settings")]
    [SerializeField] private float verticalAmplitude = 2f; // Amplitud del movimiento vertical
    [SerializeField] private float verticalSpeed = 2f;     // Velocidad del movimiento vertical
    [Header("Shooting settings")]
    [SerializeField] private GameObject enemyBullet;       // Prefab de las balas
    [SerializeField] private Transform firePoint;          // Punto desde el que dispara
    [SerializeField] private float fireRate = 3f;          // Frecuencia de disparo

    private Animator animator;                             // Referencia al componente Animator
    private float nextFire = 0f;                           // Tiempo para el próximo disparo
    private float initialY;                                // Posición inicial en Y

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialY = transform.position.y;

        // Movimiento inicial hacia la izquierda
        rb.velocity = new Vector2(-speed, 0);
    }

    void Update()
    {
        // Movimiento horizontal y oscilación vertical
        HandleMovement();

        // Disparar balas
        HandleShooting();
    }

    // Movimiento hacia la izquierda y oscilación vertical
    private void HandleMovement()
    {
        // Movimiento horizontal hacia la izquierda
        rb.velocity = new Vector2(-speed, rb.velocity.y);

        // Movimiento vertical oscilatorio
        float newY = initialY + Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    // Disparar balas desde el FirePoint
    private void HandleShooting()
    {
        if (Time.time >= nextFire)
        {
            if (Random.Range(0, 2) == 1) // Probabilidad de disparar
            {
                Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            }
            nextFire = Time.time + fireRate; // Actualizar tiempo para el próximo disparo
        }
    }

    // Animación de destrucción al morir
    public void DestroyEnemy()
    {
        rb.velocity = Vector2.zero; // Detener movimiento
        animator.SetTrigger("Destroy"); // Activar animación de destrucción
        Destroy(gameObject, 0.5f); // Destruir después de la animación
    }
}