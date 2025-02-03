using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    // RIGIDbODY
    protected Rigidbody2D rb;
    [SerializeField] protected float speed = 5f;
    protected bool destroy = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
