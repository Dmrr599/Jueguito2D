using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public Transform blanco;
    // Start is called before the first frame update
    void Start()
    {
        blanco = GameObject.Find("Piter").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(blanco.position.x,minX,maxX),
        Mathf.Clamp(blanco.position.y,minY,maxY),
        blanco.position.z-1);
        
    }
}
