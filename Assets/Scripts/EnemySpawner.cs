using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // SPAWNER DE ENEMIGOS en 8,4 a 8,1
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject quickEnemy;
    [SerializeField] private float spawnRate = 1f;
    private int dado;
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
            dado = Random.Range(0, 3);
            Debug.Log(dado);
            
            if (dado == 1)
            {
                Instantiate(basicEnemy, new Vector2(8, Random.Range(1, 5)), Quaternion.identity);
            }
            else if (dado == 2)
            {
                Instantiate(quickEnemy, new Vector2(8, 4.62f), Quaternion.identity);
            }
            
            nextSpawn = Time.time + spawnRate;
            
        }
    }



}
