using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPosicionamiento : MonoBehaviour
{

        // Declaracion de variables
    public GameObject arSpawnObjeto;
    public GameObject indicadorLugar;
    public GameObject disparo;
    private GameObject objetoSpwaneado;
    private Pose LugarPose; // Pose hace referencia a Position y Rotation
    private ARRaycastManager aRRaycastManager;
    private bool lugarPoseValid = false;



    // Start is called before the first frame update
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>(); // creamos una linea recta que nos sirva para disparar contra el enemigo
        disparo.SetActive(false);// de primeras no disparara nada, el primer golpe genera los enemigos
    }

    // Update is called once per frame
    void Update()
    {
        // Una vez spwaneado los enemigos y colocados en su posición ya si podremos disponer de los disparos
        // por lo que pondremos SetActive en true.

        if(objetoSpwaneado == null && lugarPoseValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
            ARPlaceObject();
            disparo.SetActive(true);
        }

        // Funciones que nos ayudaran a refrescar el juego spawneando nuevos enemigos cada vez que uno muera

        UpdateLugarPose();
        UpdateindicadorLugar();  
    }

    // Aquí se consigue lo anteriormente mencionada, respwan de enemigos en la misma posicion en la que se encontraban

    void UpdateindicadorLugar(){
        if(objetoSpwaneado == null && lugarPoseValid){
            indicadorLugar.SetActive(true);
            indicadorLugar.transform.SetPositionAndRotation(LugarPose.position, LugarPose.rotation);
        }
        else{
            indicadorLugar.SetActive(false);
        }

    }

    // Con esta funcion contabilizamos los golpes/toques, y despues spawnear en la posicion los enemigos. La bala golpeara lo que se encuentre en la linea mediante Raycast
    void UpdateLugarPose(){
        var centroPantalla = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var golpes = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(centroPantalla,golpes, TrackableType.Planes);

        lugarPoseValid = golpes.Count > 0;
        if(lugarPoseValid){
            LugarPose = golpes[0].pose;
        }

    }

    // Funcion con la que colocamos todos los enemigos en sus posiciones, esta funcion la pasamos despues dentro de Update para generar el enemigo mediante los  parametros que le hemos pasado

    void ARPlaceObject(){
        objetoSpwaneado = Instantiate(arSpawnObjeto,LugarPose.position, LugarPose.rotation);
    }



    


    
}

