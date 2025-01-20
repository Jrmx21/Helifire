using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // audio
    public AudioClip desctructionSound;
    public AudioClip hurtSound;
    [SerializeField] public GameObject player;
    private int health = 3;

    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button finalScoreButton;

    private bool isInvulnerable = false;

    public bool poweredUp = false;
    private int score = 0;
    private SpriteRenderer playerSprite;

    public void updateHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
                finalScoreText.color = Color.yellow;
                // SONIDO DE VICTORIA
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        finalScoreText.text = "Score: " + score + "\nHigh Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();

    }

    public int getScore()
    {
        return score;
    }
    public void addScore(int score)
    {
        this.score += score;

    }
    public void substractScore(int score)
    {
        this.score -= score;
    }

    public int getTime()
    {
        return (int)Time.time;
    }
    public void setPoweredUp(bool poweredUp)
    {
        this.poweredUp = poweredUp;

        if (poweredUp)
        {
            StartCoroutine(powerUpDurationCoroutine());
        }
    }

    public void AddHealth(int health)
    {
        this.health += health;
    }

    // Método para restar vida
    public void subtractHealth(int damage)
    {
        if (!isInvulnerable)
        {
            health -= damage;
            Debug.Log("Vidas: " + health);
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);

            if (health > 0)
            {
                StartCoroutine(InvulnerabilityCoroutine());
            }
        }
    }

    // Getter y setter
    public int getHealth()
    {
        return health;
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    // Corrutina para invulnerabilidad y parpadeo
    private IEnumerator InvulnerabilityCoroutine()
    {
        isInvulnerable = true;
        float elapsedTime = 0f;
        bool isVisible = true;

        while (elapsedTime < 2f)
        {
            isVisible = !isVisible;
            playerSprite.enabled = isVisible; // Alternar visibilidad
            elapsedTime += 0.1f;
            yield return new WaitForSeconds(0.1f); // Tiempo entre parpadeos
        }

        playerSprite.enabled = true; // Asegurar que sea visible al final
        isInvulnerable = false;
    }

    // Corrutina para la duración del power-up
    private IEnumerator powerUpDurationCoroutine()
    {
        Debug.Log("Power-up activado");
        yield return new WaitForSeconds(10f); // Espera 10 segundos
        poweredUp = false; // Desactiva el power-up
        Debug.Log("Power-up desactivado");
    }

    // Update is called once per frame
    void Update()
    {
        // YOU LOSE --------- game over
        if (health == 0)
        {
            Animator playerAnimator = player.GetComponent<Animator>();
            playerAnimator.Play("DestroyAnimation");
            AudioSource.PlayClipAtPoint(desctructionSound, transform.position);
            Destroy(player, 0.5f);
            health = -1;
            updateHighScore();
            finalScoreText.gameObject.SetActive(true);

            finalScoreButton.gameObject.SetActive(true);
        }
    }
}
