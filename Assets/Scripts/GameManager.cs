using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // audio
    public AudioClip desctructionSound;
    public AudioClip hurtSound;
    [SerializeField] public GameObject player;
    private int health = 3;
    private bool isInvulnerable = false;
    private SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerSprite = player.GetComponent<SpriteRenderer>();
    }

    // Método para restar vida
    public void sustractHealth(int damage)
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

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Animator playerAnimator = player.GetComponent<Animator>();
            playerAnimator.Play("DestroyAnimation");
            AudioSource.PlayClipAtPoint(desctructionSound, transform.position);
            Destroy(player, 0.5f);
            health = -1;
        }
    }
}
