using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D c1){
        if(c1.tag=="cuerpo"){
            // Jugador.puntos++;
            // Jugador.sonmoneda.Play();
            Destroy(gameObject);
            // Debug.Log("Monedas recolectadas: " + Jugador.puntos);
        }
    }
}
