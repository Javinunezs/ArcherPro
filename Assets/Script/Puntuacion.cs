using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puntuacion : MonoBehaviour
{
    TextMeshProUGUI puntuacionTexto;
    GameObject TablaPuntuacionUI;
    public static int punto;

    // Con este Script hacemos que se sumen los puntos de cada enemigo muerto, y que despues se muestren en una tabla detras de los enemigos
    // Cada vez que matamos un enemigo aparece la puntuacion conseguida de ese enemigo, y por detras una tabla en la que se suman los puntos
    // para ver cuantos se han conseguido

    private void Start(){
        gameObject.GetComponent<Disparo>().enabled = true; // Se activa una vez que se activa el disparo
        TablaPuntuacionUI = GameObject.FindGameObjectWithTag("TablaPuntuacionCanvas"); // Tabla donde luego aparecera la puntuacion
        puntuacionTexto = GameObject.FindGameObjectWithTag("PuntuacionTabla").GetComponent<TextMeshProUGUI>(); // Puntuacion

    }

    // Aquí se realizará la suma de puntos despues de cada colisión
    private void Update(){
        puntuacionTexto.text = "Puntos: " + punto.ToString();
    }
}
