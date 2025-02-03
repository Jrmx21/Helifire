using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    // Prefabs de los power ups
    [Header("Power Ups")]
    [SerializeField] private GameObject multiShotPowerUp;
    [SerializeField] private GameObject heartPowerUp;
    [SerializeField] private GameObject poisonPowerUp;

    // Tiempo entre spawns
    [Header("Spawning Settings")]
    [SerializeField][Range(0,50)] private float spawnInterval = 20f;

    // Área de spawn
    [SerializeField] private Vector2 spawnAreaMin=new Vector2(-6, 6);
    [SerializeField] private Vector2 spawnAreaMax=new Vector2(6, 6);

    void Start()
    {
        // Iniciar la corrutina para spawnear power-ups
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            // Elegir un power-up aleatorio
            GameObject powerUpToSpawn = GetRandomPowerUp();

            // Generar una posición aleatoria dentro del área de spawn
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            // Instanciar el power-up en la posición generada
            Instantiate(powerUpToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private GameObject GetRandomPowerUp()
    {
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex)
        {
            case 0:
                return multiShotPowerUp;
            case 1:
                return heartPowerUp;
            case 2:
                return poisonPowerUp;
            default:
                return null; // Esto no debería ocurrir
        }
    }
}
