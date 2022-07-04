using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script que realiza la explosion al entrar en contacto la bala con el cuerpo de las arañas

public class Explota : MonoBehaviour
{
    public GameObject explosion;
    public GameObject puntoToSpawn; // punto en el que hará spawn el enemigo
    public GameObject enemigoSpawn; // enemigo que va a hacer spawn
    Vector3 killPos;
    Quaternion killRot;
    public float waitTime= 3.0f; // tiempo de espera
    bool balaColision = false; // evitamos darle a varias mariposas


    // Una vez la bala ha dado contra el enemigo lo que haremos será sumarle una puntuacion, y hacer desaparecer al enemigo en concreto, para
    // luego llamar a la funcion de ReSpawn y que aparezca de nuevo

    private void OnCollisionEnter(Collision collision){
        if(collision.transform.tag == "Spider" && balaColision == false){ // Solo hará efecto con los objetos marcados con la etiqueta Spider
            Destroy(collision.transform.gameObject);
            Puntuacion.punto += 10;

            balaColision = true; // Activamos que la bala y el objeto han colisionado

            // Destruiremos la posicion del objeto que ha sido colisionado
            killPos = collision.transform.position; 
            killRot = collision.transform.rotation;
            StartCoroutine(ReSpawnEnemigo());
            Destroy(Instantiate(explosion, collision.transform.position, collision.transform.rotation), waitTime); // WaiitTime hace referencia al tiempo de espera antes de renacer
            Destroy(Instantiate(puntoToSpawn, collision.transform.position, collision.transform.rotation), waitTime);
        }
    }

    // Pondremos otra vez al enemigo como si la bala no le hubiese dado para que haga el enemigo respwan con todas las propiedades iniciales y asi poder volver a matarlo.
    // El respwan tardara 3s establecido arriba en la declaracion de variables
    IEnumerator ReSpawnEnemigo(){
        yield return new WaitForSeconds(waitTime);
        Instantiate(enemigoSpawn, killPos, killRot);
        balaColision = false;
        Destroy(gameObject);
    }
}
