using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inicio : MonoBehaviour
{

    public string NivelNombre;

    public void CargarNivel()
    {
        SceneManager.LoadScene(NivelNombre);
    }


   
}
