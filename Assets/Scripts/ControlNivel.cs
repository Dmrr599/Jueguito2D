using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Http;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class ControlNivel : MonoBehaviour
{
    public Piter Jugador;
    public GameObject puntoInicio;
    public GameObject[] Niveles;
    public int NumNivel;
    public GameObject NivelActual;
    public Text TextNivel;
    public Text TextPuntos;
    public Text TextVidas;
    public Text TextGameOver;
    public InputField txtid;
    public Button btnenviar;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        NivelActual=Instantiate(Niveles[NumNivel]);
        NivelActual.transform.SetParent(this.transform); 
        // StartCoroutine(getRequest("http://localhost:5000/player/"+id));   
    }
    // IEnumerator getRequest(string uri)
    // {
    //     UnityWebRequest uwr = UnityWebRequest.Get(uri);
    //     yield return uwr.SendWebRequest();
    //     if (uwr.isNetworkError){
    //         Debug.Log("Error"+uwr.error);
    //     }else{
    //         Debug.Log("Recibiendo: "+uwr.downloadHandler.text);
    //     }
    // }
    // IEnumerator postRequest(string uri, string bodyjsonString){
    //     var request = new UnityWebRequest(uri, "POST");
    //     byte[] bodyRaw = Encoding.UTF8.GetBytes(bodyjsonString);
    //     request.uploadHandler = (UploadHandler) new UploadHandlerraw(bodyRaw);
    //     request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
    //     request.SetRequestHeader("Content-Type","application/json");
    //     yield return request.SendWebRequest();
    //     Debug.Log("Status Code: "+ request.responseCode);
    // }
    // [System.Serializable]
    // public class datos_juego{
    //     public int puntos;
    //     public int vidas;
    //     public int nivel;
    //     public string tiempo;
    // }

    // Update is called once per frame
    void Update()
    {
        TextNivel.text="Nivel: "+(NumNivel+1);
        TextPuntos.text="Puntaje: "+Jugador.puntos;
        TextVidas.text=""+Jugador.vidas;
        
        if(Jugador.vidas==0){
            Jugador.animarlo.SetBool("Morir", true);
            Jugador.sonperder.Play();
            Jugador.sonfondo.Stop();
            Jugador.Muerto=true;
            TextGameOver.text="Game Over \n Pulsa 'r' para reiniciar el Juego";

            if(Input.GetKeyDown("r")){
                TextGameOver.text = "";
                Jugador.animarlo.SetBool("Morir", false);
                Jugador.vidas=3;
                Jugador.puntos=0;
                Jugador.sonfondo.Play();
                Destroy(NivelActual);
                NivelActual=Instantiate(Niveles[NumNivel]);
                NivelActual.transform.SetParent(this.transform);
                Jugador.Muerto = false;
                Jugador.gameObject.transform.position=Jugador.puntoInicio.transform.position;
            }
        }else if(Jugador.siguienteNivel){
            Jugador.sonfondo.Play();
            TextGameOver.text = "Nivel Completado";

            if(Input.GetKeyDown("s")){
                Jugador.sonfondo.Play();
                Jugador.puntos=0;
                Jugador.gameObject.transform.position=Jugador.puntoInicio.transform.position;
                TextGameOver.text="";
                Destroy(NivelActual);
                NumNivel+=1;
                NivelActual = Instantiate(Niveles[NumNivel]);
                Jugador.siguienteNivel=false;
            }
        }
    }
}
