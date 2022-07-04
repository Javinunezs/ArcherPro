using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que controla el disparo de una bala elegida

public class Disparo : MonoBehaviour
{
    


    public Transform arCamera;
    public GameObject proyectil;
    public float disparoForce = 700.0f;

    // Update is called once per frame
    // Conseguimos con esta funcion cargar la bala en unity y hacer que esta salga tras tocar la pantalla, la dotaremos de fuerza la bala para que tenga efecto al salir
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            GameObject bala = Instantiate(proyectil, arCamera.position, arCamera.rotation) as GameObject; //campo que nos permite añadir el proyectil que deseamos
            bala.GetComponent<Rigidbody>().AddForce(arCamera.forward * disparoForce); // Hacemos que la esfera tenga un cuerpo rigido
        }
    }
}



 