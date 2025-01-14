using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
