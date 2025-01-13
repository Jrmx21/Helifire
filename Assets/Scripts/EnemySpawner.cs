using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // SPAWNER DE ENEMIGOS en 8,4 a 8,1
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private float spawnRate = 5f;
    private float nextSpawn = 0f;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // SPAWNEAR ENEMIGOS
        if (Time.time >= nextSpawn)
        {
            Instantiate(basicEnemy, new Vector2(8, Random.Range(4,1)), Quaternion.identity);
            nextSpawn = Time.time + spawnRate;
        }
    }


    
}
