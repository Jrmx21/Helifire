using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInput : MonoBehaviour
{
    private Animator animator;
    [Header("Shoot")]

    [Tooltip("Punto desde el que se dispara el 'bullet'")] public Transform FirePoint;
    [SerializeField] private GameObject bulletPrefab;
    [Header("Movement")]
    [SerializeField][Range(0, 10)][Tooltip("Velocidad del jugador")] private float speed = 5f;

    [Header("Screen Limits")]
    [SerializeField] [Tooltip("Coordenada límite del jugador horizontal, tanto como + como en -")] private float limiteHorizontal = 6.4f;
    [SerializeField] [Tooltip("Coordenada límite del jugador vertical inferior")] private float limiteVerticalInferior = -4.86f;
    [SerializeField]  [Tooltip("Coordenada límite del jugador vertical superior")]private float limiteVerticalSuperior = -1f;
    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame


    private void FireMultiShot()
    {
        // Bala central (hacia arriba)
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

        // Bala en ángulo hacia la izquierda
        GameObject leftBullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        leftBullet.transform.rotation = FirePoint.rotation * Quaternion.Euler(0, 0, 30); // Rotar 30 grados hacia la izquierda

        // Bala en ángulo hacia la derecha
        GameObject rightBullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        rightBullet.transform.rotation = FirePoint.rotation * Quaternion.Euler(0, 0, -30); // Rotar 30 grados hacia la derecha
    }

    void Update()
    {
        // DISPARO JUGADOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameManager.poweredUp)
            {
                FireMultiShot();

            }
            else
            {
                Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
            }

        }
        // MOVIMIENTO JUGADOR
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {

            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        // LIMITACIONES MAPA
        if (transform.position.y > limiteVerticalSuperior)
        {
            transform.position = new Vector2(transform.position.x, limiteVerticalSuperior);
        }
        if (transform.position.y < limiteVerticalInferior)
        {
            transform.position = new Vector2(transform.position.x, limiteVerticalInferior);
        }
        if (transform.position.x < -limiteHorizontal)
        {
            transform.position = new Vector2(-limiteHorizontal, transform.position.y);
        }
        if (transform.position.x > limiteHorizontal)
        {
            transform.position = new Vector2(limiteHorizontal, transform.position.y);
        }

        // ESTADOS JUGADOR

        // establece estado idle y moving
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
}
