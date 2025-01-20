using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -1);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // Si el nombre es MultiShot, se activa el power up
            if (gameObject.tag == "MultiShot")
            {
                Debug.Log("PowerUp MultiShot");
                gameManager.setPoweredUp(true);
            }
            else if (gameObject.tag == "Heart")
            {
                gameManager.AddHealth(1);
            }
            else if (gameObject.tag == "Poison")
            {
                gameManager.subtractHealth(1);
            }
            Destroy(gameObject);
        }

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
