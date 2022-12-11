using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // public Piter Jugador;
    public Rigidbody2D EnemigoR;
    public float velocidad=3.1f;
    // Start is called before the first frame update
    void Start()
    {
        EnemigoR=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemigoR.velocity = new Vector2(-velocidad, EnemigoR.velocity.y);
    }
    
    private void OnTriggerEnter2D(Collider2D c1){
        if(c1.tag=="borde"){
            velocidad*=-1;
            Vector3 escala = transform.localScale;
            escala.x*=-1;
            transform.localScale=escala;
        }
        if (c1.tag=="pies"){
            Destroy(gameObject);
        }
    }
}
