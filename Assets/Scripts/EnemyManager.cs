using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // RIGIDbODY
    protected Rigidbody2D rb;
    [SerializeField] protected float speed = 5f;

    protected float timer;
    protected bool destroyFlag = false;
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
