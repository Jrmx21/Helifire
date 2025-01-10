using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerInput : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float speed = 5f;
    [SerializeField] private enum State { Idle, Moving, Attacking, Dead };
    [SerializeField] private State state = State.Idle;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        // MOVIMIENTO JUGADOR
        if (Input.GetKey(KeyCode.W))
        {

            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
         if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
         if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
         if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        // LIMITACIONES MAPA
        if (transform.position.y>-1)
        {
            transform.position = new Vector2(transform.position.x, -1);
        }
        if (transform.position.y<-4.86f)
        {
            transform.position = new Vector2(transform.position.x, -4.86f);
        }
        if (transform.position.x<-7.37f)
        {
            transform.position = new Vector2(-7.37f, transform.position.y);
        }
        if (transform.position.x>7.37f)
        {
            transform.position = new Vector2(7.37f, transform.position.y);
        }

        // ESTADOS JUGADOR

        // establece estado idle y moving
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            state = State.Moving;
            animator.SetBool("moving", true);
        }
        else
        {
            state = State.Idle;
            animator.SetBool("moving", false);
        }
    }
}
