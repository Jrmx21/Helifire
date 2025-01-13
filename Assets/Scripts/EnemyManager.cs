using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // RIGIDbODY
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //    Initial direction
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1f * speed * Time.deltaTime, 0);



    }

    // Update is called once per frame
    void Update()
    {

    }
}
