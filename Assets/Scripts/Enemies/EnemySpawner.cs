using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemies")]
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject quickEnemy;
    [SerializeField] private GameObject stealthEnemy;
    [Header("Spawning Settings")]

    [SerializeField][Range(0, 5)] private float spawnRate = 1f;
    [SerializeField][Range(0, 30)][Tooltip("Cantidad base de enemigos por ciclo")] private int baseEnemyCount = 1;
    [SerializeField][Min(1)][Tooltip("Límite máximo de enemigos por ciclo")] private int maxEnemyCount = 3;
    [SerializeField][Range(0f, 40f)][Tooltip("Tiempo entre incrementos de dificultad (en segundos)")] private float difficultyIncreaseRate = 20f;

    private float nextSpawn = 0f;
    private float nextDifficultyIncrease = 0f;
    private int currentEnemyCount; // Cantidad actual de enemigos por ciclo

    void Start()
    {
        currentEnemyCount = baseEnemyCount; // Inicializamos con el valor base
        nextDifficultyIncrease = Time.time + difficultyIncreaseRate;
    }

    void Update()
    {
        // Incrementar la dificultad a intervalos
        if (Time.time >= nextDifficultyIncrease && currentEnemyCount < maxEnemyCount)
        {
            currentEnemyCount++;
            nextDifficultyIncrease = Time.time + difficultyIncreaseRate;
        }

        // Generar enemigos
        if (Time.time >= nextSpawn)
        {
            for (int i = 0; i < currentEnemyCount; i++)
            {
                Vector2 spawnPosition = new Vector2(8, Random.Range(1f, 5f)); // Rango de aparición

                int randomValue = Random.Range(1, 101); // Probabilidad ponderada de aparición

                if (randomValue <= 60)
                {
                    Instantiate(basicEnemy, spawnPosition, Quaternion.identity);
                }
                else if (randomValue <= 85)
                {
                    Instantiate(stealthEnemy, new Vector2(8, 2.4f), Quaternion.identity);
                }
                else
                {
                    Instantiate(quickEnemy, spawnPosition, Quaternion.identity);
                }
            }

            nextSpawn = Time.time + spawnRate;
        }
    }
}
