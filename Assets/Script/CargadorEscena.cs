using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Añadir en este script los cambios de escena cargados con el script de inicio

public class CargadorEscena : MonoBehaviour
{
   // Función que nos permite cerrar la aplicación
   public void QuitarJuego()
   {
    Application.Quit();
    Debug.Log("salir!");
   }
}
