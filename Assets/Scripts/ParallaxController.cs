using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private Vector2 velocidadFondo = new Vector2(-0.03f, 0);
    private Vector2 velocidadNubes = new Vector2(-0.05f, 0);
   private Vector2 velocidadMar = new Vector2(-0.1f, 0);
    // ke?


    private Vector2 offset;

    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.name == "Nubes")
        {
            offset = velocidadFondo;
        }
        else if (this.name == "Mar")
        {
            offset = velocidadMar ;
        }
        else if (this.name == "Fondo")
        {
            offset = velocidadNubes;
        }
        else
        {
            return;
        }
        material.mainTextureOffset += offset *Time.deltaTime *Vector2.right;
        if (material == null)
        {
            Debug.LogError("Material no encontrado");
        }
    }
}
