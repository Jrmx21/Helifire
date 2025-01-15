using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject quickEnemy;
    [SerializeField] private GameObject stealthEnemy; // Nuevo tipo de enemigo
    [SerializeField] private float spawnRate = 1f;
    private int dado;
    private float nextSpawn = 0f;

    void Update()
    {
        // SPAWNEAR ENEMIGOS
        if (Time.time >= nextSpawn)
        {
            dado = Random.Range(0, 4); // Incluye posibilidad de 3 tipos de enemigos
            Debug.Log(dado);

            Vector2 spawnPosition = new Vector2(8, Random.Range(1f, 5f)); // Rango de aparición

            switch (dado)
            {
                case 1:
                    Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(quickEnemy, spawnPosition, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(stealthEnemy, new Vector2(8, 2.5f), Quaternion.identity); 
                    break;
            }

            nextSpawn = Time.time + spawnRate;
        }
    }
}
