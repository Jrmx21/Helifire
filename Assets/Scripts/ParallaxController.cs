using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadFondo = new Vector2(0.007f, 0);
    [SerializeField] private Vector2 velocidadNubes = new Vector2(0.003f, 0);
    [SerializeField] private Vector2 velocidadMar = new Vector2(0.001f, 0);
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
        Debug.Log(offset);
        material.mainTextureOffset += offset *Time.deltaTime *Vector2.right;
        if (material == null)
        {
            Debug.LogError("Material no encontrado");
        }
    }
}
