using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private int health = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // resta vida metodo
    public void sustractHealth(int damage)
    {
        health -= damage;
        Debug.Log("Vidas: " + health);
    }

    // getter y setter 
    public int getHealth()
    {
        return health;
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Animator playerAnimator = player.GetComponent<Animator>();
            playerAnimator.Play("DestroyAnimation");
            Destroy(player, 0.5f);
            health = -1;
        }

    }
}
