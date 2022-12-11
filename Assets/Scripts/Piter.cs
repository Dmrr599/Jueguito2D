using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piter : MonoBehaviour
{
    //Fuerza con la que el jugador va a saltar
    public float FuerzaSalto;
    //Controlar el cuerpo del jugador
    public Rigidbody2D piter;
    //Controlar la rapidez de desplazamiento
    public float velocidad=2.5f;
    //Permite a los pies detectar el suelo
    public Animator animarlo;
    public bool EnSuelo=false;
    public bool Muerto = false;
    // Para saber hacia donde mira
    // public bool MirarDerecha=true;
    // Asigna la variable al Animator
    public AudioSource sonfondo;
    public AudioSource sonsaltar;
    public AudioSource sonperder;
    public AudioSource sonvida;
    public AudioSource sonmoneda;
    public int puntos = 0;
    public int vidas = 3;
    public GameObject puntoInicio;
    public bool siguienteNivel = false;
    

    void Awake(){
        piter = GetComponent <Rigidbody2D>();
        animarlo = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animarlo.SetFloat("Salto",0);
        animarlo.SetFloat("Velocidad",0);

        if(Muerto){

        }else{
            // float horizontal=Input.GetAxis("Horizontal");
            if(Input.GetKeyDown("space")&&EnSuelo){
                Saltar();
            } 
            if(Input.GetKey("right")&&EnSuelo){
                ControlMovimiento();
                animarlo.SetFloat("Velocidad",velocidad);
                piter.transform.rotation=Quaternion.Euler(0,0,0);
            } 
            if(Input.GetKey("left")&&EnSuelo){
                ControlMovimiento();
                animarlo.SetFloat("Velocidad",velocidad);
                piter.transform.rotation=Quaternion.Euler(0,180,0);
            } 
        }
    }

    void Saltar(){
        animarlo.SetFloat("Salto", FuerzaSalto); // Relaciona la variable Salto con la Fuerza del Salto
        sonsaltar.Play();
        piter.AddForce(new Vector2(0, FuerzaSalto));
    }
    private void ControlMovimiento(){
        float horizontal=Input.GetAxisRaw("Horizontal");
        piter.velocity=new Vector2(horizontal*velocidad, piter.velocity.y);
    }
}
