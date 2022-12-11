using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiesPiter : MonoBehaviour
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

    // Para entrar en colisión
    private void OnTriggerEnter2D(Collider2D c1){
        if(c1.tag=="plataforma"){
            Jugador.EnSuelo=true;
        }
        if(c1.tag=="acido"){
            Jugador.sonperder.Play();
            Jugador.vidas --;
            Jugador.gameObject.transform.position = Jugador.puntoInicio.transform.position;
        }
    }
    // Para salir de colisión
    private void OnTriggerExit2D(Collider2D c1){
        if(c1.tag=="plataforma"){
            Jugador.EnSuelo=false;
        }
    }
}
