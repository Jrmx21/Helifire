using System.Collections;
using UnityEngine;

public class ZigZagEnemy : EnemyManager
{   [SerializeField] private float shieldDuration = 3f;       // Duración del escudo activo
    [SerializeField] private float shieldCooldown = 5f;       // Tiempo de recarga del escudo
    [SerializeField] private GameObject enemyBullet;          // Prefab de las balas
    [SerializeField] private Transform firePoint;             // Punto desde el que dispara
    [SerializeField] private float fireRate = 2f;             // Tiempo entre disparos
    [SerializeField] private Animator animator;               // Animador para las animaciones del escudo
    private bool isShieldActive = false;                      // Estado del escudo
    private float nextShieldToggle = 0f;                      // Tiempo para alternar el escudo
    private float nextFire = 0f;                              // Tiempo para el próximo disparo

    void Start()
    {
        speed=200f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed * Time.deltaTime, 0); // Movimiento inicial hacia la izquierda

        nextShieldToggle = Time.time + shieldCooldown; // Programar el primer uso del escudo
    }

    void Update()
    {
        HandleShield();
        HandleShooting();
    }

    // Manejar el estado del escudo
    private void HandleShield()
    {
        if (Time.time >= nextShieldToggle)
        {
            if (isShieldActive)
            {
                DeactivateShield();
            }
            else
            {
                ActivateShield();
            }
        }
    }

    // Activar el escudo
    private void ActivateShield()
    {
        Debug.Log("¡El escudo se ha activado!");
        isShieldActive = true;
        animator.SetBool("ShieldActive", true); // Activar animación del escudo
        nextShieldToggle = Time.time + shieldDuration; // Programar desactivación del escudo
    }

    // Desactivar el escudo
    private void DeactivateShield()
    {
        Debug.Log("¡El escudo se ha desactivado!");
        isShieldActive = false;
        animator.SetBool("ShieldActive", false); // Desactivar animación del escudo
        nextShieldToggle = Time.time + shieldCooldown; // Programar la próxima activación
    }

    // Disparar balas periódicamente
    private void HandleShooting()
    {
        if (Time.time >= nextFire)
        {
            Instantiate(enemyBullet, firePoint.position, firePoint.rotation); // Generar bala
            nextFire = Time.time + fireRate; // Actualizar tiempo para el próximo disparo
        }
    }

    // Destruir al enemigo si no tiene el escudo activo
    public void TakeDamage()
    {
        if (!isShieldActive)
        {
            DestroyEnemy();
        }
        else
        {
            Debug.Log("¡El enemigo está protegido por el escudo!");
        }
    }

    // Animación de destrucción
    public void DestroyEnemy()
    {
        rb.velocity = Vector2.zero; // Detener movimiento
        animator.SetTrigger("Destroy"); // Activar animación de destrucción
        Destroy(gameObject, 0.5f); // Destruir después de la animación
    }
}
