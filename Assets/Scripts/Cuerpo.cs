using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuerpo : MonoBehaviour
{
    public Piter Jugador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D c1){
        if(c1.tag=="moneda"){
            Jugador.puntos++;
            Jugador.sonmoneda.Play();
        }

        if(c1.tag=="vida"){
            Jugador.vidas++;
            Jugador.sonvida.Play();
        }

        if (c1.tag=="enemigo"){
            Jugador.animarlo.SetBool("Morir", true);
            Jugador.sonperder.Play();
            Jugador.sonfondo.Stop();
            Jugador.Muerto=true;
            Jugador.vidas--;
        }

        if(c1.tag=="siguienteNivel"){
            Jugador.siguienteNivel = true;
        }
    }
}
